using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapons : MonoBehaviour
{
    public Transform muzzle;
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
    #region max byllets
    private const float MAX_BULLETS_BIG = 100;
    private const float MAX_BULLETS_MID = 60;
    private const float MAX_BULLETS_SMALL = 30;
    #endregion
    //Velocidad de la bala
    #region speed
    private const float SPEED_BIG = 5000;
    private const float SPEED_MID = 4000;
    private const float SPEED_SMALL = 3000;
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
    //balas que le quedan a esa arma
    private float current_bullets;
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
            fire_distance = FIRE_DISTANCE_LONG;
            loader_size = LOADER_SIZE_SMALL;
            reload_time = RELOAD_TIME_MID;
            firing_rate = FIRING_RATE_SLOW;
            speed = SPEED_BIG;
        }

        else if (kind_weapon == list_kind_weapon.Rifle)
        {

            fire_distance = FIRE_DISTANCE_MID;
            loader_size = LOADER_SIZE_MID;
            reload_time = RELOAD_TIME_SLOW;
            firing_rate = FIRING_RATE_MID;
            speed = SPEED_MID;
        }

        else if (kind_weapon == list_kind_weapon.Gun)
        {
            fire_distance = FIRE_DISTANCE_SHORT;
            loader_size = LOADER_SIZE_BIG;
            reload_time = RELOAD_TIME_FAST;
            firing_rate = FIRING_RATE_FAST;
            speed = SPEED_SMALL;
        }
        current_bullets = loader_size;
        reloading = false;

    }

    void Update()
    {
        if (firing)
        {
            firing_aux_rate += Time.deltaTime;
            if (firing_aux_rate >= firing_rate)
                firing = false;
        }
        if (reloading)
        {
            reload_aux_time += Time.deltaTime;
            if (reload_aux_time >= reload_time)
            {
                current_bullets = loader_size;
                reloading = false;

            }
        }
        
    }

    public void Shoot()
    {
        if (current_bullets > 0 && !firing)
        {
            var bullet = bulletPool.GetComponent<Pool>().GetType<Bullet>();
            my_bullet = bullet.GetComponent<Bullet>();
            bullet.transform.position = muzzle.position;
            bullet.transform.rotation = muzzle.rotation;
            my_bullet.SetActive();
            my_bullet.SetDamage((int)damage);
            my_bullet.SetSpeed((int)speed);
            current_bullets--;
            firing = true;

        }
        else
        {
            Reload();
        }
    }

    public void Reload()
    {
        reloading = true;
    }
    public void Throw()
    {

    }
    /// <summary>
    /// Cambia la visibilidad del objeto dependiendo de si es poseido o está en el suelo
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            transform.SetParent(other.GetComponent<Transform>());
            Transform hand = other.transform.Find("mixamorig12_Hips/mixamorig12_Spine/mixamorig12_Spine1/mixamorig12_Spine2/mixamorig12_LeftShoulder/mixamorig12_LeftArm/mixamorig12_LeftForeArm/mixamorig12_LeftHand");
            transform.SetParent(hand);
            transform.position = hand.position;

        }
    }
}
