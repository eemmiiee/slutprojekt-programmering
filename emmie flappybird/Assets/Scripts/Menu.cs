using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public KeyCode restartKey = KeyCode.Space;
    void Update(){
        if(Input.GetKeyDown(restartKey)){
            RestartGame();
        }
    }
    public void RestartGame(){
        FindObjectOfType<DeathLogic>().StopAllCoroutines(); //Stops time from slowing down
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void ExitGame(){
        Debug.Log("Quit game");
        Application.Quit();
    }
}
