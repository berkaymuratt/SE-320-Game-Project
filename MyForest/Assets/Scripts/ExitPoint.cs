using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPoint : MonoBehaviour
{
    public Text interactionText;
    public Text informationText;
    public Hero hero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Hero"))
        {
            interactionText.text = "";
            informationText.text = "";
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
}
