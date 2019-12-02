using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudGun : MonoBehaviour
{
    /// <summary>
    /// Referencia del prebab de la imagen de la bala
    /// </summary>
    public Image bulletImage;
    /// <summary>
    /// Array de imagenes de bala
    /// </summary>
    private GameObject [] bullets;
  

    public void Initialized(int Count)
    {

        bullets = new GameObject[Count];
        for (int i = 0; i < Count; i++)
        {
            bullets[i] = Instantiate(bulletImage, default, default, this.transform).gameObject;
        }
    }

    public void Shoot(int bulletsCount) 
    {
      
        bullets[bulletsCount-1].SetActive(false);
       
    }
    public void Reload() 
    {
        for (int i = 0; i < bullets.Length;i++)
        {
            bullets[i].SetActive(true);
        }

    }
}
