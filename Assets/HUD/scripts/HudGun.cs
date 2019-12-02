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
    /// <summary>
    /// Indica la cantidad de balas que se van a mostrar en el hud
    /// </summary>
    private int bulletsCount;


    void Start()
    {
       
        bulletsCount = 6;

        bullets = new GameObject[bulletsCount];
        for (int i = 0; i < bulletsCount;i++) 
        {
            bullets[i] = Instantiate(bulletImage,default,default,this.transform).gameObject;
        }
        
    }
    public void Shoot() 
    {
        if (bulletsCount > 0) 
        {
            bullets[bulletsCount-1].SetActive(false);
            bulletsCount--;
        }
        


    }
}
