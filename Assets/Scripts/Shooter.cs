using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float projectileLifetime = 5;
    [SerializeField] float fireRate = .2f;
    Coroutine firingCoroutine;

    public bool isFiring; 
    void Start()
    {
        
    }

    
    void Update()
    {
        Fire();
    }
    void Fire(){

        if(isFiring && firingCoroutine == null) {


          firingCoroutine =  StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        

    }
    IEnumerator FireContinuously(){

        while(true){
        
        GameObject instance = Instantiate(projectilePrefab, transform.position
        , Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

        if(rb != null) {

            rb.velocity = transform.up * projectileSpeed;
        }

        Destroy(instance, projectileLifetime);
        yield return new WaitForSeconds(fireRate);
    }
    } 
}
