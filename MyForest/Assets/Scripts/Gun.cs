using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour
{
    private Animation m_Animation; 
    private AudioSource m_AudioSource;

    public Camera fpsCam;
    public AudioClip shootingAudio;
    public AudioClip outOfAmmoAudio;

    public int m_bulletCount;
    public float range = 100f;

    private Enemy m_Enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        m_Animation = gameObject.GetComponent<Animation>();
        m_AudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyRespawn();
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

                RaycastHit hit;
                bool isHit = Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);

                if (isHit)
                {
                    Transform other = hit.transform;
                    
                    Debug.Log(other.gameObject.name);

                    if (other.gameObject.tag.Equals("EnemyCharacter"))
                    {
                        m_Enemy = other.GetComponent<Enemy>();
                        m_Enemy.Disappear();
                    }
                }
            }
            else
            {
                PlayOutOfAmmoSound();
            }
        }
    }
    
    public void CheckEnemyRespawn()
    {
        if (m_Enemy != null)
        {
            if (!m_Enemy.gameObject.activeInHierarchy)
            {
                m_Enemy.UpdateRespawnTime();
                if (m_Enemy.CheckRespawn())
                {
                    m_Enemy.Respawn();
                }
            }
        }
    }

    private void PlayShootingSound()
    {
        m_AudioSource.clip = shootingAudio;
        m_AudioSource.Play();
    }

    private void PlayOutOfAmmoSound()
    {
        m_AudioSource.clip = outOfAmmoAudio;
        m_AudioSource.Play();
    }
}
