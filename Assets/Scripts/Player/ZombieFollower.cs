using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollower : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed *= 100;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = (targetPosition.transform.position - this.transform.position).normalized;
        rb.AddForce(direction *  speed * Time.deltaTime, ForceMode.Acceleration);

        transform.LookAt(targetPosition.transform);



    }
}
