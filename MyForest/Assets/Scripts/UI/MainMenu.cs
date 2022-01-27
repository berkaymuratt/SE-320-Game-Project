using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadingCanvas;
    public GameObject MenuCanvas;
    public GameObject HowToPlay;

    public void PlayGame()
    {
        MenuCanvas.SetActive(false);
        LoadingCanvas.SetActive(true);
        
        int newSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        SceneManager.LoadScene(newSceneIndex);
        Debug.Log("Loaded...");
    }

    public void DisplayHowToPLay()
    {
        MenuCanvas.SetActive(false);
        HowToPlay.SetActive(true);
    }

    public void GoBack()
    {
        HowToPlay.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
