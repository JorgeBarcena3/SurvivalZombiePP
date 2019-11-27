using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolElement : MonoBehaviour
{

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
        return this.gameObject.activeSelf;
    }

    /// <summary>
    /// Activa un objeto
    /// </summary>
    public void SetActive()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// Desactiva un objeto
    /// </summary>
    public void SetInactive()
    {
        GetComponent<Rigidbody>().isKinematic = true;
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
