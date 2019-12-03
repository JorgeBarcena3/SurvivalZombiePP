using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    public bool CanAttack = false;
    private ZombieFollower myZombie;
    void Start()
    {
        myZombie = GetComponentInParent<ZombieFollower>();
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player") 
        {
            CanAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            CanAttack = false;
        }

    }
    private void Attack() 
    {

    }
}
 