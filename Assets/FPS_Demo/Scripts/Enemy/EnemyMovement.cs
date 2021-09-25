using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement  : MonoBehaviour
{
    private Transform m_goal;

    private NavMeshAgent m_agent;

    void Start()
    {
        m_goal = PlayerController.Instance.transform;
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.destination = m_goal.position;
    }

    private void Update()
    {
        m_agent.velocity = transform.forward * Time.deltaTime;
    }
}