using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour
{
    private Animation m_RecoilAnimation; 
    private AudioSource m_AudioSource;
    
    public AudioClip shootingSound;
    
    // Start is called before the first frame update
    void Start()
    {
        m_RecoilAnimation = gameObject.GetComponent<Animation>();
        m_AudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        PlayShootingSound();
        m_RecoilAnimation.Play();
    }

    private void PlayShootingSound()
    {
        m_AudioSource.clip = shootingSound;
        m_AudioSource.Play();
    }
}
