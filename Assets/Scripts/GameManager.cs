using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Character;
    public static GameManager instance;
    private int _charIndex;
    public int CharIndex{
        get {return _charIndex;}
        set {_charIndex = value;}
    }

    // public bool IsPlayerDead = false;


    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinsihedLoading;
    }

    private void OnDisable(){
        SceneManager.sceneLoaded -= OnLevelFinsihedLoading;
    }

   void OnLevelFinsihedLoading(Scene scene, LoadSceneMode mode){
        if(scene.name == "Gameplay"){
            Instantiate(Character[CharIndex]);
        }
   }

    public void Restart(){
        SceneManager.LoadScene("Gameplay");
    }

    public void Home(){
        SceneManager.LoadScene("MainMenu");
    }
}
