using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class Explosion : MonoBehaviour
{

    public ParticleSystemMultiplier explosionEffects;
    private AudioSource m_AudioSource;
        
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        m_AudioSource.Play();
        explosionEffects.PlayAll();
    }
}
