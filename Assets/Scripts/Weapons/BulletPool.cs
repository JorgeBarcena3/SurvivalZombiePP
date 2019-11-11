using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletPool : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform poolPosition;
    [Range(min:0,max:int.MaxValue)]
    public int bulletCount;
    public GameObject bullet;
    private List<GameObject> bullets;
    void Start()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            bullets.Add(Instantiate(bullet,poolPosition));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetBullet(Transform origin)
    { 
        return bullets.Where(i => i.GetComponent<Bullet>().GetActive() == false).FirstOrDefault();
    }
}
