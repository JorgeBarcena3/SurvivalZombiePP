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
    private int damage;
    private int speed;
    private bool active;
    private int distance;
    private Transform poolPosition;
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

    public bool GetActive() { return active; }
    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Living>() != null)
        {
            collision.gameObject.GetComponent<Living>().MakeDamage(damage);

        }
        SetInactive();
    }
    public void SetActive()
    {
        active = true;
        this.gameObject.SetActive(true);
    }
    public void SetInactive()
    {
        active = false;
        gameObject.GetComponent<Transform>().position = poolPosition.position;
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
    public void SetDistance(int distance)
    {
        this.distance = distance;
    }
    public void SetPositionPool(Transform poolPosition) { this.poolPosition = poolPosition; }
    public int GetDistance() { return distance; }
    public int GetDamage() { return damage; }
    public int GetSpeed() { return speed; }
}
