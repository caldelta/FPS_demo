using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement  : MonoBehaviour
{
    private Transform m_goal;

    private NavMeshAgent m_agent;

    void Start()
    {
        
        m_agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        m_goal = PlayerController.Instance.transform;
        m_agent.destination = m_goal.position;

    }
}