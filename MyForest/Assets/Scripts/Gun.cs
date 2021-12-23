using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour
{
    private Animation m_Animation; 
    private AudioSource m_AudioSource;

    public AudioClip shootingSound;
    public AudioClip outOfAmmoSound;

    private int m_bulletCount;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Animation = gameObject.GetComponent<Animation>();
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        m_bulletCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (!m_Animation.IsPlaying("gun-recoil"))
        {
            if (m_bulletCount > 0)
            {
                PlayShootingSound();
                m_Animation.Play("gun-recoil");
                m_bulletCount--;
            }
            else
            {
                PlayOutOfAmmoSound();
            }
        }
    }

    private void PlayShootingSound()
    {
        m_AudioSource.clip = shootingSound;
        m_AudioSource.Play();
    }

    private void PlayOutOfAmmoSound()
    {
        m_AudioSource.clip = outOfAmmoSound;
        m_AudioSource.Play();
    }
}
