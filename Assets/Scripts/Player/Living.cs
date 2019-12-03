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
    public int initHealth = 100;
    public KindOfLiving myKind;
    public Image myHealthBar;
    private int maxHealth;
    private int health;
    void Start()
    {
        maxHealth = initHealth; health = maxHealth;
        if(myHealthBar!=null)
            myHealthBar.transform.localScale = Vector3.one;
    }
    /// <summary>
    /// Reinicia o inicia la vida a la establecida por defecto desde el editor o 100
    /// </summary>
    public void InitLiver()
    {
        maxHealth = initHealth ; health = maxHealth;
        if (myHealthBar != null)
            myHealthBar.transform.localScale = Vector3.one;
    }
    /// <summary>
    /// Reinicia o inicia la vida a la establecida por parámetros
    /// </summary>
    /// <param name="health">vida con la que se va a iniciar el ente</param>
    public void InitLiver(int health)
    {
        maxHealth = health; this.health = maxHealth;
        if (myHealthBar != null)
            myHealthBar.transform.localScale = Vector3.one;
    }

   
    public void MakeDamage(int damage)
    {
        health -= damage;
        if (myHealthBar != null)
        {
            myHealthBar.transform.localScale =new Vector3((float)health/maxHealth, 1, 1);
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
