using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletPool : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 poolPosition;
    [Range(min:0,max:1000)]
    public int bulletCount;
    public GameObject bullet;
    private List<GameObject> bullets;
    private GameObject aux; 
    void Start()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < bulletCount; i++)
        {
            aux = Instantiate(bullet, poolPosition, Quaternion.Euler(0, 0, 0));
            bullets.Add(aux);
            aux.GetComponent<Bullet>().SetInactive();

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetBullet()
    { 
        return bullets.Where(i => i.GetComponent<Bullet>().GetActive() == false).FirstOrDefault();
    }
}
