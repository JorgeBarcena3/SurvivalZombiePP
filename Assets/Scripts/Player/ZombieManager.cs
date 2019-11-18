using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Instancia los zombies cada x tiempo
/// </summary>
public class ZombieManager : MonoBehaviour
{

    /// <summary>
    /// Cada cuanto tiempo se spawnea un zombie
    /// </summary>
    public float timeToSpawn;

    /// <summary>
    /// Pool donde se guardan los zombies
    /// </summary>
    public Pool pool;

    /// <summary>
    /// Posicion de spawn
    /// </summary>
    public Vector3 positionToSpawn;

    /// <summary>
    /// Tiempo actual 
    /// </summary>
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > timeToSpawn)
        {
            GameObject zombie = pool.GetComponent<Pool>().GetType<ZombieFollower>();
            ZombieFollower component = zombie.GetComponent<ZombieFollower>();
            zombie.transform.position = positionToSpawn;
            component.SetActive();
            currentTime = 0;

        }
        else
            currentTime += Time.deltaTime;


    }
}
