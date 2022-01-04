using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyNavMesh : MonoBehaviour
{
    public Transform heroTransform;
    public float enemySpeed;
    
    private NavMeshAgent m_Agent;
    private GameObject m_EnemyCharacter;

    // Start is called before the first frame update
    void Start()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_EnemyCharacter = transform.GetChild(1).gameObject;
        m_Agent.speed = enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_EnemyCharacter.activeInHierarchy)
        {
            m_Agent.SetDestination(heroTransform.position);
        }
    }

    public void Move()
    {
        m_Agent.speed = enemySpeed;
    }

    public void Stop()
    {
        m_Agent.speed = 0;
    }
    
    public void IncreaseSpeed()
    {
        enemySpeed+=0.25f;
    }
}
