using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Clase de pool base
/// </summary>
public class Pool : MonoBehaviour
{

    /// <summary>
    /// Posicion donde se almacenaran las pools
    /// </summary>
    public Vector3 poolPosition;

    /// <summary>
    /// Cantidad de objetos que se intanciaran como maximo
    /// </summary>
    [Range(min: 0, max: 1000)]
    public int objectCount;

    /// <summary>
    /// Objeto del cual se hará el pool
    /// </summary>
    public List<GameObject> objectPrefabs;

    /// <summary>
    /// Lista de objetos en el pool
    /// </summary>
    private List<GameObject> poolList;
    
    /// <summary>
    /// Instanciamos los objetos del pull
    /// </summary>
    void Start()
    {    

        poolList = new List<GameObject>();

        foreach (GameObject objeto in objectPrefabs)
        {
            for (int i = 0; i < objectCount; i++)
            {
                GameObject aux = Instantiate(objeto, poolPosition, Quaternion.Euler(0, 0, 0));
                PoolElement elem = aux.GetComponent<PoolElement>();
                elem.SetPositionPool(aux.transform);
                elem.SetInactive();
                poolList.Add(aux);


            }
        }
      

    }

    /// <summary>
    /// Devolvemos un objeto del tipo deseado
    /// </summary>
    /// <returns></returns>
    public GameObject GetType<T>() where T : PoolElement
    {
        return poolList.Where(i => i.GetComponent<T>() != null && i.GetComponent<T>().GetActive() == false).FirstOrDefault();
    }
}
