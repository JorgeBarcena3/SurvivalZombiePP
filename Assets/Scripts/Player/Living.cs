using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum KindOfLiving
{
    ZOMBIE,
    PLAYER,
}
public class Living : MonoBehaviour
{
    public int health = 100;//{ private set; get; }
    public KindOfLiving myKind;
    public Image myHealthBar;

   
    public void MakeDamage(int damage)
    {
        health -= damage;
        if (myHealthBar != null)
        {
            myHealthBar.transform.localScale =new Vector3((float)health/100, 1, 1);
        }
        if (health <= 0)
            Dead();
    }

    public void Dead()
    {
        switch (myKind)
        {
            case KindOfLiving.PLAYER:
                break;
            case KindOfLiving.ZOMBIE:
                GetComponent<ZombieFollower>().SetInactive();
                break;
        }

    }
}
