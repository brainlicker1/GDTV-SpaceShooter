using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{     
   // [SerializeField] float sceneLoadDelay =2f;
    ScoreKeeper scoreKeeper;

     void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame(){
        
        SceneManager.LoadScene("Game");
        
    }
    public void LoadTitle(){
        SceneManager.LoadScene("Title");
       
    }
    public void LoadDeath(){
       SceneManager.LoadScene("Death");
    }
    public void QuitGame(){
        Debug.Log("ending game");
        Application.Quit();
    }

  
}
