using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadingCanvas;
    
    public void PlayGame()
    {
        gameObject.SetActive(false);
        LoadingCanvas.SetActive(true);
        
        int newSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        SceneManager.LoadScene(newSceneIndex);
        Debug.Log("Loaded...");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
