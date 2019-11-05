using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControllerAxis
{
    public static string LHorizontal = "Horizontal";
    public static string LVertical = "Vertical";
    public static string RHorizontal = "Mouse X";
    public static string RVertical = "Mouse Y";


}

public class PlayerControls : MonoBehaviour
{
    /// <summary>
    /// Velocidad del jugador
    /// </summary>
    public float speed;

    /// <summary>
    /// Rigidbody component
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// Componente animator
    /// </summary>
    private Animator anim;



    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetJoystickNames();
        //Controles de movimiento con mando
        rb.AddForce(-Vector3.right * -Input.GetAxis(ControllerAxis.LHorizontal) * speed * 50 * Time.deltaTime, ForceMode.Acceleration);
        rb.AddForce(Vector3.forward * -Input.GetAxis(ControllerAxis.LVertical) * speed * 50 * Time.deltaTime, ForceMode.Acceleration);

        float angle = Mathf.Atan2(Input.GetAxis(ControllerAxis.RVertical), Input.GetAxis(ControllerAxis.RHorizontal)) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(new Vector3(0, angle, 0));


        //Controles de movimiento con teclado -- Solo Debug
        if (Input.GetKey(KeyCode.W))
        { rb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse); }
        if (Input.GetKey(KeyCode.S))
        { rb.AddForce(-Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse); }
        if (Input.GetKey(KeyCode.A))
        { rb.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode.Impulse); }
        if (Input.GetKey(KeyCode.D))
        { rb.AddForce(-Vector3.left * speed * Time.deltaTime, ForceMode.Impulse); }


    }

    /// <summary>
    /// Update cuando se han cargado todas las fisicas
    /// </summary>
    void FixedUpdate()
    {
        //  Cambiamos la animacion segun la velocidad
        if (Input.GetAxis(ControllerAxis.LHorizontal) == 0 && Input.GetAxis(ControllerAxis.LVertical) == 0)
        {
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("Moving", true);
        }
    }
}
