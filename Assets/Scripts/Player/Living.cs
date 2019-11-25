using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : MonoBehaviour
{
    public int health { private set; get; }
    // Start is called before the first frame update
    public void MakeDamage(int damage)
    {
        health -= damage;
    }
}
