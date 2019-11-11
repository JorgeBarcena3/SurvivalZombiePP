using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    [HideInInspector]
    public GameObject owner;
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public int speed;
    private bool active;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        active = false;
    }
    void Update()
    {
        if (active)
        {

        }
        
    }

    public bool GetActive() { return active; }
    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != owner)
        {
            collision.gameObject.GetComponent<Living>().MakeDamage(damage);
            active = false;
        }
    }
}
