using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityStandardAssets.Effects;

public class Enemy : MonoBehaviour
{
    public float respawnTime;
    private float respawnTimer;
    public Explosion explosion;

    public AudioSource enemyAudioSource;
    public AudioClip respawnAudio;
    public AudioClip disappearAudio;
    
    void Start()
    {
        respawnTimer = 0;
    }

    public bool CheckRespawn()
    {
        if (respawnTimer>=respawnTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateRespawnTime()
    {
        respawnTimer += Time.deltaTime;
    }

    public void Respawn()
    {
        respawnTimer = 0;
        gameObject.SetActive(true);
        
        enemyAudioSource.clip = respawnAudio;
        enemyAudioSource.Play();
    }

    public void Disappear()
    {
        explosion.Play();
        gameObject.SetActive(false);

        enemyAudioSource.clip = disappearAudio;
        enemyAudioSource.Play();
    }
}
