using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapons : MonoBehaviour
{
    //instancia de la bala
    [HideInInspector]
    public GameObject bullet;
    
    /// <summary>
    /// Espacio del cargador
    /// </summary>
    #region loader sizes
    private const int LOADER_SIZE_BIG = 12;
    private const int LOADER_SIZE_MID = 5;
    private const int LOADER_SIZE_SMALL = 1;
    #endregion
    /// <summary>
    /// Tiempo de recarga
    /// </summary>
    #region reload times
    private const float RELOAD_TIME_FAST = 1;
    private const float RELOAD_TIME_MID = 2;
    private const float RELOAD_TIME_SLOW = 3;
    #endregion
    /// <summary>
    /// tiempo entre disparos
    /// </summary>
    #region firing rates
    private const float FIRING_RATE_FAST = 0.8f;
    private const float FIRING_RATE_MID = 1.2f;
    private const float FIRING_RATE_SLOW = 3;//es tan larga la espera porque es para el arma que solo tiene una bala en el cargador
    #endregion
    /// <summary>
    /// velocidad de disparo
    /// </summary>
    #region speed
    private const int SPEED_BIG = 300;
    private const int SPEED_MID = 200;
    private const int SPEED_SMALL = 100;
    #endregion
    /// <summary>
    /// daño que hace el proyectil
    /// </summary>
    #region damage
    private const int DAMAGE_BIG = 100;
    private const int DAMAGE_MID = 60;
    private const int DAMAGE_SMALL = 30;
    #endregion
    //tamaño del cargador
    private int loader_size;
    //tiempo de recarga
    private float reload_time;
    //cadencia de disparo
    private float firing_rate;
    //daño de disparo
    private int damage;
    //velocidad de la bala
    private int speed;
    //balas que le quedan a esa arma
    private int current_bullets;
    public GameObject bulletPool;
    private Bullet my_bullet;
    private bool reloading;
    private float reload_aux_time = 0;
    private float firing_aux_rate = 0;
    private bool firing = false;

    //Tipos de arma que hay
    public enum list_kind_weapon { Sniper, Rifle, Gun };
    //el arma que es este en cuestion, se elige desde el editor
    public list_kind_weapon kind_weapon;
    // Start is called before the first frame update
    void Start()
    {
        if (kind_weapon == list_kind_weapon.Sniper)
        {
            loader_size = LOADER_SIZE_SMALL;
            reload_time = RELOAD_TIME_MID;
            firing_rate = FIRING_RATE_SLOW;
            speed = SPEED_BIG;
            damage = DAMAGE_BIG;
        }

        else if (kind_weapon == list_kind_weapon.Rifle)
        {

            loader_size = LOADER_SIZE_MID;
            reload_time = RELOAD_TIME_SLOW;
            firing_rate = FIRING_RATE_MID;
            speed = SPEED_MID;
            damage = DAMAGE_MID;
        }

        else if (kind_weapon == list_kind_weapon.Gun)
        {
            loader_size = LOADER_SIZE_BIG;
            reload_time = RELOAD_TIME_FAST;
            firing_rate = FIRING_RATE_FAST;
            speed = SPEED_SMALL;
            damage = DAMAGE_SMALL;
        }
        current_bullets = loader_size;
        reloading = false;
        GetComponentInChildren<HudGun>().Initialized(loader_size);
        this.transform.Find("Canvas").GetComponent<ActiveCanvasOnPosession>().setCanvasInactive();

    }

    void Update()
    {
        if (firing)
        {
            firing_aux_rate += Time.deltaTime;
            if (firing_aux_rate >= firing_rate)
            {
                firing_aux_rate = 0;
                firing = false;
            }
               
        }
        if (reloading)
        {
            reload_aux_time += Time.deltaTime;
            if (reload_aux_time >= reload_time)
            {
                current_bullets = loader_size;
                reload_aux_time = 0;
                reloading = false;

            }
        }
        
    }

    public void Shoot()
    {
        if (current_bullets > 0)
        {
            if (!firing) 
            {
                var bullet = bulletPool.GetComponent<Pool>().GetType<Bullet>();
                my_bullet = bullet.GetComponent<Bullet>();
                my_bullet.SetActive();
                my_bullet.shoot(damage, speed, transform.position, transform.rotation);
                GetComponentInChildren<HudGun>().Shoot(current_bullets);

                current_bullets--;
                firing = true;

            }
            

        }
        else
        {
            Reload();
            GetComponentInChildren<HudGun>().Reload();
        }
    }

    public void Reload()
    {
        reloading = true;
    }
    public void Throw()
    {
        this.transform.Find("Canvas").GetComponent<ActiveCanvasOnPosession>().setCanvasInactive();

    }
    /// <summary>
    /// Cambia la visibilidad del objeto dependiendo de si es poseido o está en el suelo
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            transform.SetParent(other.GetComponent<Transform>());
            Transform hand = other.transform.Find("mixamorig12_Hips/mixamorig12_Spine/mixamorig12_Spine1/mixamorig12_Spine2/mixamorig12_LeftShoulder/mixamorig12_LeftArm/mixamorig12_LeftForeArm/mixamorig12_LeftHand/socket");
            transform.SetParent(hand);
            transform.position = hand.position;
            transform.rotation = hand.rotation;
            this.transform.Find("Canvas").GetComponent<ActiveCanvasOnPosession>().SetCanvasActive();

        }
    }
}