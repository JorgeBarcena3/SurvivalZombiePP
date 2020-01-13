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
    public static string Correr = "L3";
    public static string Apuntar = "Left Trigger";
    public static string Ok = "Fire1";

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
    [HideInInspector]
    public Animator anim;
    /// <summary>
    /// Referencia del player accesible desde cualquier punto del proyecto
    /// </summary>
    public static PlayerControls instance;



    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetInteger("Armament", 0);


    }

    // Update is called once per frame
    void Update()
    {
        detectarInput();

        applyMovement(modifySpeed(speed));

        applyRotation();

    }

    /// <summary>
    /// Detecta los input del jugador
    /// </summary>
    private void detectarInput()
    {
        detectarDisparo();

        detectarApuntado();
    }

    /// <summary>
    /// Detecta si el jugador esta apuntando o no
    /// </summary>
    private void detectarApuntado()
    {
        if (Input.GetAxis(ControllerAxis.Apuntar) > 0)
        {
            disparar();
        }
    }

    /// <summary>
    /// Detectamos su el jugador esta disparando o no
    /// </summary>
    private void detectarDisparo()
    {
        //Disparo 
        if (Input.GetAxis(ControllerAxis.Apuntar) > 0)
        {
            apuntar();
        }
    }

    /// <summary>
    /// Realizamos la accion de apuntar
    /// </summary>
    private void apuntar()
    {
        Vector3 direction = transform.forward;
        Debug.DrawRay(transform.position, direction, Color.green);
    }

    /// <summary>
    /// Movificamos la velocidad del jugador
    /// </summary>
    /// <param name="currentSpeed"></param>
    /// <returns></returns>
    private float modifySpeed(float currentSpeed)
    {
        //Detectamos si esta corriendo o no
        if (Input.GetAxis(ControllerAxis.Correr) > 0)
        {
            currentSpeed *= 2;
            anim.SetBool("Running", true);
        }
        else 
        {
            anim.SetBool("Running", false);
        }

        return currentSpeed;
    }

    /// <summary>
    /// Aplicamos la rotacion al jugador
    /// </summary>
    private void applyRotation()
    {
        float horizontal = Input.GetAxis(ControllerAxis.RVertical);
        float vertical = Input.GetAxis(ControllerAxis.RHorizontal);

        Vector3 direccion = new Vector3(horizontal, vertical);

        float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
        rb.rotation = angle != 0 ? Quaternion.Euler(new Vector3(0, -(angle - 180), 0)) : rb.rotation;


    }

    /// <summary>
    /// Àplicamos el movimiento al jugador
    /// </summary>
    /// <param name="currentSpeed"></param>
    private void applyMovement(float _currentSpeed)
    {
       
        Vector3 desiredVelocity = Input.GetAxis(ControllerAxis.LHorizontal) * Vector3.right
                                + Input.GetAxis(ControllerAxis.LVertical) * -Vector3.forward;

        rb.velocity = Vector3.Lerp(rb.velocity, desiredVelocity * _currentSpeed, Time.deltaTime);

        setSpeedOfAnim(_currentSpeed);

        Debug.Log(_currentSpeed);

        setSpeedOfAnim(_currentSpeed);
        /*if ((Input.GetAxis(ControllerAxis.LVertical) <= 0 && transform.rotation.eulerAngles.y < 90 && transform.rotation.eulerAngles.y > -90) || (Input.GetAxis(ControllerAxis.LHorizontal) >= 0 && transform.rotation.eulerAngles.y > 90 && transform.rotation.eulerAngles.y < 270))
        {
            anim.SetBool("Forward", true);
        }
        else 
        {
            anim.SetBool("Forward", false);
        }*/

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
    /// Esta función lanza la animación de disparar
    /// </summary>
    private void disparar()
    {
        if (GetComponentInChildren<Weapons>()) 
        {
            anim.SetBool("Shooting",true);
        }
            
    }
    /// <summary>
    /// Esta funcion llama a la funcion del arma equipada que dispara
    /// A esta función se la llama desde un evento puesto en la animación de disparar
    /// </summary>
    public void shoot()
    {
        if (GetComponentInChildren<Weapons>())
        {
            GetComponentInChildren<Weapons>().Shoot();
        }
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
    public void resetShootingWeapon() { GetComponentInChildren<Weapons>().firingFalse(); anim.SetBool("Shooting", false); }
}
