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
    public ParticleSystem muzzleFlash;

    public int m_bulletCount;
    public float range = 100f;

    private Enemy m_EnemyCharacter;
    

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
                muzzleFlash.Play();
                m_Animation.Play("gun-recoil");
                m_bulletCount--;

                RaycastHit hit;
                bool isHit = Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);

                if (isHit)
                {
                    Transform other = hit.transform;

                    if (other.gameObject.tag.Equals("EnemyCharacter"))
                    {
                        m_EnemyCharacter = other.GetComponent<Enemy>();
                        m_EnemyCharacter.Disappear();
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
        if (m_EnemyCharacter != null)
        {
            if (!m_EnemyCharacter.gameObject.activeInHierarchy)
            {
                m_EnemyCharacter.UpdateRespawnTime();
                if (m_EnemyCharacter.CheckRespawn())
                {
                    m_EnemyCharacter.Respawn();
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
