using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    ScreenShake cameraShake;

     void Awake()
    {
     cameraShake = Camera.main.GetComponent<ScreenShake>();
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null) {

            TakeDamage(damageDealer.GetDamage());
            OnHit();
            ShakeCamera();
            damageDealer.Hit();

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
            Destroy(gameObject);
        }

    }   
    void OnHit(){
        if(hitEffect != null) {
            ParticleSystem instnace = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instnace.gameObject, instnace.main.duration + instnace.main.startLifetime.constantMax);
        }
    }
}
