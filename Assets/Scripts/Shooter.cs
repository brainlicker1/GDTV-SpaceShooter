using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{   
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float projectileLifetime = 5;
    [SerializeField] float baseFireRate = .2f;
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minFiringRate = 0.1f;
    Coroutine firingCoroutine;
    AudioController audioController;

    [HideInInspector] public bool isFiring; 
     void Awake() {
        audioController = FindObjectOfType<AudioController>();
    }
    void Start()
    {
        if(useAI){
            isFiring = true;
        }
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

        float timeToNextProjectile = Random.Range(baseFireRate - firingRateVariance, 
        baseFireRate + firingRateVariance);

        timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minFiringRate, float.MaxValue);
        
        Destroy(instance, projectileLifetime);
        audioController.PlayShootingClip();
        
        yield return new WaitForSeconds(timeToNextProjectile );
    }
    } 
}
