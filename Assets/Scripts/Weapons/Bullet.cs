using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolElement
{
    // Start is called before the first frame update
    [HideInInspector]
    public Rigidbody rb;
    private int damage;

    public void shoot(int damage, float speed, Vector3 position, Quaternion rotation)
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        this.damage = damage;
        transform.position = position;
        transform.rotation = rotation;
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }
  
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Living>() != null)
        {
            collision.gameObject.GetComponent<Living>().MakeDamage(damage);

        }
        SetInactive();
    }

   
   
   
}
