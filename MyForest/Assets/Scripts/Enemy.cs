using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class Enemy : MonoBehaviour
{
    public float respawnTime;
    private float spawnTimer;
    public Explosion explosion;
    
    void Start()
    {
        spawnTimer = 0;
    }

    public bool CheckRespawn()
    {
        if (spawnTimer>=respawnTime)
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
        spawnTimer += Time.deltaTime;
    }

    public void Respawn()
    {
        spawnTimer = 0;
        gameObject.SetActive(true);
    }

    public void Disappear()
    {
        explosion.Play();
        gameObject.SetActive(false);
    }
}
