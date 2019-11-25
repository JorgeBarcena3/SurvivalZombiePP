using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolElement
{
    // Start is called before the first frame update
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public GameObject owner;
    private int damage;
    private int speed;
    private int distance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        active = false;
    }
    void Update()
    {
        if (active)
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Acceleration);
        }
        
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Living>() != null)
        {
            collision.gameObject.GetComponent<Living>().MakeDamage(damage);

        }
        SetInactive();
    }
  

    public void SetSpeed(int speed)
    {
      
        this.speed = speed;
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public void SetDistance(int distance)
    {
        this.distance = distance;
    }

    public int GetDistance() { return distance; }
    public int GetDamage() { return damage; }
    public int GetSpeed() { return speed; }
}
