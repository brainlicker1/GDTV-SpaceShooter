using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{

    [SerializeField] Slider hpSlider;
    [SerializeField] Health playerHealth;

     [SerializeField] TextMeshProUGUI scoreText;
     ScoreKeeper scoreKeeper;
     Health health;
     
          void Awake()
    {
       scoreKeeper = FindObjectOfType<ScoreKeeper>();
       health = FindObjectOfType<Health>();
       hpSlider.maxValue = playerHealth.GetHealth();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
      hpSlider.value = playerHealth.GetHealth();

        
        if(scoreText != null){
           scoreText.text = scoreKeeper.GetScore().ToString("0000000");
    
        }
    }
     
   
}
