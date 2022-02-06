using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offSet;

    Material material;
    void Awake()
   {
       material = GetComponent<SpriteRenderer>().material;
   }

   
    void Update()
    {
        offSet = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offSet;
    }
}
