using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //controles de movimiento con mando
        rb.AddForce(Vector3.left * Input.GetAxis("Left Stick Horizontal 1") * speed * Time.deltaTime, ForceMode.Acceleration);
        rb.AddForce(Vector3.forward * Input.GetAxis("Left Stick Vertical 1") * speed * Time.deltaTime, ForceMode.Acceleration);

        

        //controles de movimiento con teclado
        if (Input.GetKey(KeyCode.W))
        { rb.AddForce(Vector3.forward* speed * Time.deltaTime,ForceMode.Impulse); }
        if (Input.GetKey(KeyCode.S))
        { rb.AddForce(-Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse); }
        if (Input.GetKey(KeyCode.A))
        { rb.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode.Impulse); }
        if (Input.GetKey(KeyCode.D))
        { rb.AddForce(-Vector3.left * speed * Time.deltaTime, ForceMode.Impulse); }


    }
}
