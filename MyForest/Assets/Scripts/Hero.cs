using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public enum EndTypes
{
    CAUGHT,
    DIED,
    TIMEISOVER,
    ESCAPED,
}

public class Hero : MonoBehaviour
{
    public Gun gun;

    private int currentHealth;
    private int maxHealth = 100;

    private float currentStamina;
    private float maxStamina = 100f;

    public Slider healthBar;
    public Slider staminaBar;

    public int requiredKeysCount;
    
    public int medkitCount;
    public int keyCount;
    
    public AudioClip[] collectAudios;

    public Text MedkitCountText;
    public Text AmmoCountText;
    public Text KeyCountText;
    public Text InformationText;
    public Text timeText;

    public float infoTextTimer;
    private float counter;
    
    public float timer;
    private bool isGameOver;

    private EndTypes EndType;

    public Text EndingText;
    public Text EndingInfoText;

    public float endingScreenTimer;

    public CanvasGroup EndingCanvasGroup;
    public GameObject OnPlayCanvas;

    private FirstPersonController fpsController;
   

    // Update is called once per frame
    void Start()
    {
        fpsController = gameObject.GetComponent<FirstPersonController>();
        
        medkitCount = 0;
        keyCount = 0;
        currentHealth = 100;
        currentStamina = 100;
        
        isGameOver = false;

        UpdateUI();
    }

    void Update()
    {
        UpdateStamina();

        if (Input.GetButtonDown("Fire1"))
        {
            gun.Shoot();
            UpdateUI();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            UseMedKit();
        }

        CheckTimer();
        CheckInfoText();

        if (isGameOver)
        {
            CheckEndTypes();
        }
    }
    
    private void UseMedKit()
    {
        if (medkitCount > 0)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth += 20;
            
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
            
                healthBar.value = currentHealth;
                medkitCount--;
                UpdateUI();
            }
            else
            {
                InformationText.text = "Your health is full !";
            }
        }
        else
        {
            InformationText.text = "You don't have any Medkit !";
        }
    }

    public void GetDamage(int value)
    {
        currentHealth -= value;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            setEndType(EndTypes.DIED);
        }
    }

    public void GetMedkit()
    {
        medkitCount++;
    }

    public void GetAmmo()
    {
        gun.m_bulletCount += 3;
    }

    public void GetKey()
    {
        keyCount++;
        InformationText.text = (requiredKeysCount-keyCount) + " Key(s) Left ..";
    }

    public void UpdateUI()
    {
        MedkitCountText.text = medkitCount.ToString();
        AmmoCountText.text = gun.m_bulletCount.ToString();
        KeyCountText.text = keyCount.ToString();
    }

    public void PlayCollectAudio(int audioIndex)
    {
        AudioSource audioSource;

        if (audioIndex == 1)
        {
            audioSource = gun.GetComponent<AudioSource>();
        }
        else
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
        
        audioSource.clip = collectAudios[audioIndex];
        audioSource.Play();
    }

    private void UpdateStamina()
    {
        if (!fpsController.IsRunning() && !Input.GetKey(KeyCode.LeftShift))
        {
            IncreaseCurrentStamina();
        }
        else
        {
            DecreaseCurrentStamina();
        }
    }

    private void IncreaseCurrentStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += Time.deltaTime*10;
            UpdateStaminaBar();
        }
    }

    private void DecreaseCurrentStamina()
    {
        if (currentStamina > 0)
        {
            currentStamina -= Time.deltaTime*10;
            UpdateStaminaBar();
        }
    }

    public float GetCurrentStamina()
    {
        return currentStamina;
    }

    private void UpdateStaminaBar()
    {
        staminaBar.value = currentStamina;
    }
    
    private void CheckInfoText()
    {
        if (!InformationText.text.Equals(""))
        {
            counter += Time.deltaTime;
        }

        if (counter >= infoTextTimer)
        {
            InformationText.text = "";
            counter = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("EnemyCharacter"))
        {
            setEndType(EndTypes.CAUGHT);
        }
    }
    
    private void CheckTimer()
    {
        if (timer <= 0)
        {
            setEndType(EndTypes.TIMEISOVER);
        }
        else
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        timer -= Time.deltaTime;

        int minute = (int) timer / 60;
        int second = (int) timer % 60;

        String time = "";

        if (minute < 10)
        {
            time += "0";
        }

        time += minute + ":";

        if (second < 10)
        {
            time += "0";
        }

        time+=second;

        timeText.text = time;

        if (timer <= 120)
        {
            timeText.color = Color.red;
        }

    }

    private void CheckEndTypes()
    {
        switch (EndType)
        {
            case EndTypes.DIED:
                GameOver(false, "..You Died..");
                break;
            case EndTypes.CAUGHT:
                GameOver(false, "..You Got Caught..");
                break;
            case EndTypes.TIMEISOVER:
                GameOver(false, "..Time is Over..");
                break;
            case EndTypes.ESCAPED:
                GameOver(true,"");
                break;
        }
    }

    public void setEndType(EndTypes types)
    {
        if (!isGameOver)
        {
            isGameOver = true;
            EndType = types;
        }
    }

    public void GameOver(bool isEscaped, String message)
    {
        if (isEscaped)
        { 
            EndingText.color = Color.white;
            EndingText.text = "You Escaped !";
        }
        else
        {
            EndingText.color = Color.red;
            EndingText.text = "Game Over";
        }
        
        EndingInfoText.text = message;
        OnPlayCanvas.SetActive(false);

        if (EndingCanvasGroup.alpha < 1)
        {
            EndingCanvasGroup.alpha += Time.deltaTime;
        }
        else
        {
            if (endingScreenTimer > 0)
            {
                endingScreenTimer -= Time.deltaTime;
            }
            else
            {
                // Freeze the Game
                Time.timeScale = 0;

                // Load the ending scene
                int newSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(newSceneIndex);
            }
        }
    }
}
