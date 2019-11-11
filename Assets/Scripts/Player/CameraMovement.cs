using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mueve la camara suavenmente, persiguiendo al jugador
/// </summary>
public class CameraMovement : MonoBehaviour
{

    /// <summary>
    /// Objeto al que perseguirá la camara
    /// </summary>
    public Transform followTarget;

    /// <summary>
    /// Velocidad de movimiento
    /// </summary>
    public float reCenterTime = 0.3f;

    /// <summary>
    /// Offset de la camara
    /// </summary>
    public Vector3 offset = new Vector3(0, 7.3f, -8.15f);

    /// <summary>
    /// Velocidad actual
    /// </summary>
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

        if (!followTarget)
        {
            this.followTarget = GameObject.Find("player").GetComponent<Transform>();
        }

    }

    // Update is called once per frame
    void Update()
    {

        //Posicion adaptada de la posicion que seguir
        Vector3 targetPosition = followTarget.position + offset;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, reCenterTime);
    }
}
