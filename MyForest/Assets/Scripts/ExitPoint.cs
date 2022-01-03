using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class ExitPoint : MonoBehaviour
{
    public Text interactionText;
    public Text informationText;
    public Hero hero;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Hero"))
        {
            if (CanEscape())
            {
                interactionText.text = "Press E to Escape";
            }
            else
            {
                informationText.text = "You need " + (hero.requiredKeysCount - hero.keyCount) + " key(s) more..!";
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals("Hero") && CanEscape() && Input.GetKeyDown(KeyCode.E))
        {
            Exit();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Hero"))
        {
            ClearTexts();
        }
    }

    private bool CanEscape()
    {
        if (hero.keyCount == hero.requiredKeysCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private void ClearTexts()
    {
        interactionText.text = "";
        informationText.text = "";
    }

    private void Exit()
    {
        ClearTexts();
        Debug.Log("EXIT SUCCESSFULLY");
    }
}
