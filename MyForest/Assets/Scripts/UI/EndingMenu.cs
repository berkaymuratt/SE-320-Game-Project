using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{
    public GameObject LoadingCanvas;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        LoadingCanvas.SetActive(true);
        
        int newSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        
        SceneManager.LoadScene(newSceneIndex);
        Debug.Log("Loaded...");
    }

    public void ReturnToMenu()
    {
        gameObject.SetActive(false);
        LoadingCanvas.SetActive(true);

        SceneManager.LoadScene(0);
        Debug.Log("Loaded...");
    }
}
