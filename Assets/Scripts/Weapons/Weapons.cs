using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapons : MonoBehaviour
{
    //instancia de la bala
    [HideInInspector]
    public GameObject bullet;
    //distancias maximas
    #region distances of fire
    private const float FIRE_DISTANCE_LONG = 300;
    private const float FIRE_DISTANCE_MID = 200;
    private const float FIRE_DISTANCE_SHORT = 100;
    #endregion
    //cantidad de balas por tipo de cargador
    #region loader sizes
    private const float LOADER_SIZE_BIG = 12;
    private const float LOADER_SIZE_MID = 5;
    private const float LOADER_SIZE_SMALL = 1;
    #endregion
    //tiempo de recarga de cada arma
    #region reload times
    private const float RELOAD_TIME_FAST = 1;
    private const float RELOAD_TIME_MID = 2;
    private const float RELOAD_TIME_SLOW = 3;
    #endregion
    //cadencia de disparo de cada arma
    #region firing rates
    private const float FIRING_RATE_FAST = 0.3f;
    private const float FIRING_RATE_MID = 0.7f;
    private const float FIRING_RATE_SLOW = 10;//es tan larga la espera porque es para el arma que solo tiene una bala en el cargador
    #endregion
    //los daños que van a provocar las distintas armas
    #region damages
    private const float DAMAGE_STRONG = 75;
    private const float DAMAGE_MID = 60;
    private const float DAMAGE_WEAK = 45;
    #endregion
    //el maximo de balas que tiene cada arma
    #region max byllets
    private const float MAX_BULLETS_BIG = 100;
    private const float MAX_BULLETS_MID = 60;
    private const float MAX_BULLETS_SMALL = 30;
    #endregion
    //Velocidad de la bala
    #region speed
    private const float SPEED_BIG = 300;
    private const float SPEED_MID = 150;
    private const float SPEED_SMALL = 80;
    #endregion
    //distancia maxima a la que se puede disparar
    private float fire_distance;
    //tamaño del cargador
    private float loader_size;
    //tiempo de recarga
    private float reload_time;
    //cadencia de disparo
    private float firing_rate;
    //daño de disparo
    private float damage;
    //velocidad de la bala
    private float speed;
    //cantidad maxima de balas
    private float max_bullets;
    //balas que le quedan a esa arma
    private float current_bullets;
    public GameObject bulletPool;
    private Bullet my_bullet;

    //Tipos de arma que hay
    public enum list_kind_weapon { Sniper, Rifle, Gun };
    //el arma que es este en cuestion, se elige desde el editor
    public list_kind_weapon kind_weapon;
    // Start is called before the first frame update
    void Start()
    {
        if (kind_weapon == list_kind_weapon.Sniper)
        {
            fire_distance = FIRE_DISTANCE_LONG;
            loader_size = LOADER_SIZE_SMALL;
            reload_time = RELOAD_TIME_MID;
            firing_rate = FIRING_RATE_SLOW;
            speed = SPEED_BIG;
            damage = DAMAGE_STRONG;
            max_bullets = MAX_BULLETS_SMALL;
        }

        else if (kind_weapon == list_kind_weapon.Rifle)
        {

            fire_distance = FIRE_DISTANCE_MID;
            loader_size = LOADER_SIZE_MID;
            reload_time = RELOAD_TIME_SLOW;
            firing_rate = FIRING_RATE_MID;
            speed = SPEED_MID;
            damage = DAMAGE_MID;
            max_bullets = MAX_BULLETS_MID;
        }

        else if (kind_weapon == list_kind_weapon.Gun)
        {
            fire_distance = FIRE_DISTANCE_SHORT;
            loader_size = LOADER_SIZE_BIG;
            reload_time = RELOAD_TIME_FAST;
            firing_rate = FIRING_RATE_FAST;
            speed = SPEED_SMALL;
            damage = DAMAGE_WEAK;
            max_bullets = MAX_BULLETS_BIG;
        }

        Swich_visibility();





    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Shoot()
    {
        var bullet = bulletPool.GetComponent<BulletPool>().GetBullet();
        my_bullet = bullet.GetComponent<Bullet>();
        bullet.transform.position = this.transform.position;
        bullet.GetComponent<Rigidbody>().rotation = GetComponentInParent<Rigidbody>().rotation;
        my_bullet.SetActive();
        my_bullet.SetDamage((int)damage);
        my_bullet.SetSpeed((int)speed);
        


    }
    public void Reload()
    {

    }
    public void Throw()
    {

    }
    /// <summary>
    /// Cambia la visibilidad del objeto dependiendo de si es poseido o está en el suelo
    /// </summary>
    private void Swich_visibility()
    {
        if (this.GetComponentInParent<Transform>() != null)
        {
            GetComponentsInChildren<MeshRenderer>().Any(i => i.enabled = false);
            
        }
        else
        {
            GetComponentsInChildren<MeshRenderer>().Any(i => i.enabled = true);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            transform.SetParent(other.GetComponent<Transform>());
            Swich_visibility();

        }
    }
}
