using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager de los controles del mando 
/// </summary>
public static class ControllerAxis
{
    public static string LHorizontal = "Horizontal";
    public static string LVertical = "Vertical";
    public static string RHorizontal = "Mouse X";
    public static string RVertical = "Mouse Y";
    public static string Disparo = "Right Trigger";
    public static string Correr = "Left Trigger";


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

        float currentSpeed = speed;

        //Detectamos si esta corriendo o no
        if (Input.GetAxis(ControllerAxis.Correr) > 0)
        {
            currentSpeed *= 2;
        }

        setSpeedOfAnim(currentSpeed);

        rb.AddForce(-Vector3.right * -Input.GetAxis(ControllerAxis.LHorizontal) * currentSpeed * 50 * Time.deltaTime, ForceMode.Acceleration);
        rb.AddForce(Vector3.forward * -Input.GetAxis(ControllerAxis.LVertical) * currentSpeed * 50 * Time.deltaTime, ForceMode.Acceleration);

        float angle = Mathf.Atan2(Input.GetAxis(ControllerAxis.RVertical), Input.GetAxis(ControllerAxis.RHorizontal)) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

        //Disparo 
        if (Input.GetAxis(ControllerAxis.Disparo) > 0)
        {
            shoot();
        }


    }

    /// <summary>
    /// Determina la velocidad de la animacion
    /// </summary>
    /// <param name="currentSpeed">Multiplicador de la velocidad de la animacion</param>
    private void setSpeedOfAnim(float currentSpeed)
    {
        float multiplicator;

        if (currentSpeed != speed)
            multiplicator = 1.5f;
        else
            multiplicator = 1f;

        anim.SetFloat("Speed", multiplicator);
    }

    /// <summary>
    /// Funcion que se llama cuando disparamos
    /// </summary>
    private void shoot()
    {
        Debug.Log("Disparando...");
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
