using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{   
   [SerializeField] float moveSpeed = 1f;
   [SerializeField] float paddingL;
   [SerializeField] float  paddingR;
    [SerializeField] float paddingT;
    [SerializeField] float paddingB;
  
    Vector2 rawInput;
    
    Vector2 minBounds;
    Vector2 maxBounds;


    // Update is called once per frame
     void Start()
    {
      InitBounds();
    }
    void Update()
    {
      Move();
    }
    void OnMove(InputValue value){
     
      rawInput = value.Get<Vector2>();
      
        
    }
    void Move(){
      Vector2 delta = rawInput  * moveSpeed * Time.deltaTime;
      Vector2 newPos = new Vector2();
      newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingL, maxBounds.x - paddingR);
      newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y +paddingB, maxBounds.y - paddingT);
      transform.position = newPos;
    }
    void InitBounds(){
      Camera mainCamera = Camera.main;
      minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
      maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
}
