using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class Enemy : MonoBehaviour
{
    private float respawnTime;
    public Explosion explosion;

    void Start()
    {
        respawnTime = 0;
    }

    public bool CheckRespawn()
    {
        if (respawnTime>=5)
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
        respawnTime += Time.deltaTime;
    }

    public void Respawn()
    {
        respawnTime = 0;
        gameObject.SetActive(true);
    }

    public void Disappear()
    {
        explosion.Play();
        gameObject.SetActive(false);
    }
}
