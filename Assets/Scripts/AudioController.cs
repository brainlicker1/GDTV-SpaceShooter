using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{   
    [Header("Shoot")]
   [SerializeField] AudioClip fireSFX;


   [Header("Damage")] 
   [SerializeField] AudioClip impatcSFX;
   [SerializeField] AudioClip explodeSFX;

  // [Header("Volume")]
   //[SerializeField] [Range(0f,1f)] float volume = 1f;


   public void PlayShootingClip(){
      PlaySfx(fireSFX, 1);
   }

   public void PlayImpactSFX() {
      
      PlaySfx(impatcSFX, 1);
   }

   public void PlayExplodeSFX(){

      PlaySfx(explodeSFX, 1);

   }

   void PlaySfx(AudioClip clip, float volume){

       if(clip != null) {

           Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,camPos,volume);
       }

   }
}
