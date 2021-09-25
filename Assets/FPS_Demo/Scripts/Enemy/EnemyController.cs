using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_enemyObject;

    [SerializeField]
    private Transform[] m_spawnPoints;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("Spawn", 0, 1);
        
    }
    private void Spawn()
    {
        var zombie = m_enemyObject[Random.Range(0, 3)];
        var spawnPoint = m_spawnPoints[Random.Range(0, 3)];
        Instantiate(zombie, spawnPoint.position, zombie.transform.rotation, transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
