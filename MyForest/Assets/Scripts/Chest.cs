using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    
    private Text m_InteractionText;
    private Hero m_Hero;
    private bool m_InChestArea;

    private void Start()
    {
        m_Hero = GameObject.Find("Hero").GetComponent<Hero>();
        m_InteractionText = GameObject.Find("InteractionText").GetComponent<Text>();
    }

    private void Update()
    {
        if (m_InChestArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed to E..");
                ClearText();
                Destroy(gameObject);
            }
        }
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
        if (other.gameObject.name.Equals("Hero"))
        {
            m_InChestArea = true;
            ChangeText();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Hero"))
        {
            m_InChestArea = false;
            ClearText();
        }
    }
}
