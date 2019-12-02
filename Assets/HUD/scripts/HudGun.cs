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
    private Image [] bullets;
    /// <summary>
    /// Guarda la dimension de la mitad del ancho de la imagen
    /// </summary>
    private float halfImageWidth;
    /// <summary>
    /// Guarda la dimension de la mitad del alto de la imagen
    /// </summary>
    private float halfImageHeight;
    /// <summary>
    /// Indica la cantidad de balas que se van a mostrar en el hud
    /// </summary>
    private int bulletsCount;


    void Start()
    {
        halfImageWidth = bulletImage.sprite.texture.width / 2;
        halfImageHeight = bulletImage.sprite.texture.height / 2;
        bulletsCount = 6;

        bullets = new Image[bulletsCount];
        for (int i = 0; i < bulletsCount;i++) 
        {
            bullets[i] = bulletImage; 
            Vector2 myPosition = new Vector2(GetComponent<RectTransform>().rect.width - halfImageWidth * (1+i), halfImageHeight);
            Instantiate(bullets[i],myPosition,transform.rotation).transform.SetParent(this.gameObject.transform);
            bullets[i].gameObject.SetActive(true);

        }
        
    }
    public void Shoot() 
    {
        if (bulletsCount > 0) 
        {
            bullets[bulletsCount-1].gameObject.SetActive(false);
            bulletsCount--;
        }
        


    }
}
