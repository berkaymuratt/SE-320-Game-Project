using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterScript : MonoBehaviour
{

    private Light m_Light;
    
    void Start()
    {
        m_Light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (m_Light.enabled)
            {
                m_Light.enabled = false;
            }
            else
            {
                m_Light.enabled = true;
            }
        }
    }
}
