using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashLight : MonoBehaviour
{
    private Light m_Light;
    public ParticleSystem muzzleFlash;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Light = gameObject.GetComponent<Light>();
        m_Light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (muzzleFlash.isPlaying)
        {
            m_Light.enabled = true;
        }
        else
        {
            m_Light.enabled = false;
        }
    }
}
