using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolElement : MonoBehaviour
{
    /// <summary>
    /// Determina si el objeto está activo o no
    /// </summary>
    protected bool active;

    /// <summary>
    /// Posicion del pool
    /// </summary>
    protected Transform poolPosition;

    /// <summary>
    /// Devuelve si el objeto está o no activado
    /// </summary>
    /// <returns></returns>
    public bool GetActive()
    {
        return active;
    }

    /// <summary>
    /// Activa un objeto
    /// </summary>
    public void SetActive()
    {

        this.gameObject.SetActive(true);
        active = true;
    }

    /// <summary>
    /// Desactiva un objeto
    /// </summary>
    public void SetInactive()
    {
        active = false;
        gameObject.GetComponent<Transform>().position = poolPosition.position;
        this.gameObject.SetActive(false);

    }

    /// <summary>
    /// Lleva el objeto a la poolPosition
    /// </summary>
    /// <param name="poolPosition"></param>
    public void SetPositionPool(Transform poolPosition)
    {
        this.poolPosition = poolPosition;
    }


}
