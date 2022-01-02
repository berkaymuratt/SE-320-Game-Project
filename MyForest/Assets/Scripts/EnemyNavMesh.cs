using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public Transform heroTransform;
    private NavMeshAgent m_Agent;
    private GameObject m_EnemyCharacter;

    // Start is called before the first frame update
    void Start()
    {
        m_Agent = gameObject.GetComponent<NavMeshAgent>();
        m_EnemyCharacter = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_EnemyCharacter.activeInHierarchy)
        {
            m_Agent.speed = 5;
            m_Agent.SetDestination(heroTransform.position);
        }
        else
        {
            m_Agent.speed = 0;
        }
    }
}
