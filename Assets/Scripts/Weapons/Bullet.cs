using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public GameObject owner;
    [HideInInspector]
    private int damage;
    [HideInInspector]
    private int speed;
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
            rb.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Acceleration);
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
    public void SetActive()
    {
        active = true;
        this.gameObject.SetActive(true);
    }
    public void SetInactive()
    {
        active = false;
        this.gameObject.SetActive(false);

    }

    public void SetSpeed(int speed)
    {
        this.speed = speed;
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public int GetDamage() { return damage; }
    public int GetSpeed() { return speed; }
}
