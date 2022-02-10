using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{   
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
     [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    ScreenShake cameraShake;
    AudioController audioController;
    ScoreKeeper scoreKeeper;
     LevelManager levelManager;

     void Awake()
    {
     cameraShake = Camera.main.GetComponent<ScreenShake>();
     audioController = FindObjectOfType<AudioController>();
     scoreKeeper = FindObjectOfType<ScoreKeeper>();
     levelManager = FindObjectOfType<LevelManager>();

    }
     void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null) {

            TakeDamage(damageDealer.GetDamage());
            OnHit();
            ShakeCamera();
            damageDealer.Hit();
            audioController.PlayImpactSFX();
        }
    }

    void ShakeCamera(){

        if(cameraShake != null && applyCameraShake){
            cameraShake.Play();
        }

    }
    void TakeDamage(int damage) {
        health -= damage;

        if(health <= 0) {
            Die();
            
           
        }

    }   
    void OnHit(){
        if(hitEffect != null) {
            ParticleSystem instnace = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instnace.gameObject, instnace.main.duration + instnace.main.startLifetime.constantMax);
        }
    }
    public int GetHealth(){

        return health;
    }
    public void Die(){
        if(!isPlayer) {
            scoreKeeper.ModifyScore(score);
        } else {
             levelManager.LoadDeath();
        }
        Destroy(gameObject);
            audioController.PlayExplodeSFX();
            
    }
    
}
