using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

     void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null) {

            TakeDamage(damageDealer.GetDamage());
            OnHit();
            damageDealer.Hit();

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
