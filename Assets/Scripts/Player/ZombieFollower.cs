using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ZombieFollower : PoolElement
{

    /// <summary>
    /// Rigidbody del zombie
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// Position to follow
    /// </summary>
    public GameObject targetPosition;

    /// <summary>
    /// Velocidad del zombie
    /// </summary>
    public float speed;

    /// <summary>
    /// Componente que controla el movimiento del zombie
    /// </summary>
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //speed *= 100;

        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetPosition.transform.position;  // Posición que persigue el NavMeshAgent
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 direction = (targetPosition.transform.position - this.transform.position).normalized;
        //rb.AddForce(direction *  speed * Time.deltaTime, ForceMode.Acceleration);

        // Movimiento con el NavMeshAgent 
        agent.destination = targetPosition.transform.position;

        transform.LookAt(targetPosition.transform);

    }
}
