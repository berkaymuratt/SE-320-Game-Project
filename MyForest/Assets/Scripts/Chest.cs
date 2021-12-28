using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public String chestType;

    private bool m_InChestArea;
    private bool m_IsChestOpened;
    private Light m_SpotLight;
    private Text m_InteractionText;

    private Hero m_Hero;

    private void Start()
    {
        m_Hero = GameObject.Find("Hero").GetComponent<Hero>();
        m_InteractionText = GameObject.Find("InteractionText").GetComponent<Text>();
        m_SpotLight = gameObject.GetComponentInChildren<Light>();
    }

    private void Update()
    {
        if (m_InChestArea && !m_IsChestOpened)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenChest();
            }
        }
    }

    public void OpenChest()
    {
        PlayChestAudio();

        int audioIndex=-1;
        
        switch (chestType)
        {
            case "MedkitChest":
                m_Hero.GetMedkit();
                audioIndex = 0;
                break;
            case "AmmoChest":
                m_Hero.GetAmmo();
                audioIndex = 1;
                break;
            case "KeyChest":
                m_Hero.GetKey();

                GameObject keyChestAudio = transform.GetChild(2).gameObject; //3rd child of KeyChest
                AudioSource audioSource = keyChestAudio.GetComponent<AudioSource>();
                audioSource.Play();

                audioIndex = 2;
                break;
        }
        m_Hero.PlayCollectAudio(audioIndex);
        m_IsChestOpened = true;
        ClearText();
        m_Hero.UpdateUI();
        m_SpotLight.enabled = false;
    }

    public void ChangeText()
    {
        m_InteractionText.text = "Press E to open chest";
    }

    public void ClearText()
    {
        m_InteractionText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Hero") && !m_IsChestOpened)
        {
            m_InChestArea = true;
            ChangeText();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Hero") && !m_IsChestOpened)
        {
            m_InChestArea = false;
            ClearText();
        }
    }

    private void PlayChestAudio()
    {
        AudioSource audioSource;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
