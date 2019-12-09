using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    /// <summary>
    /// Indica si el zombie tiene un objetivo a distancia
    /// </summary>
    private bool CanAttack = false;
    /// <summary>
    /// Referencia al componente de animación
    /// </summary>
    private Animator myAnimator;
    /// <summary>
    /// Indica la cantidad de daño que hace al atacar
    /// </summary>
    public int damage;
    /// <summary>
    /// Indica el tiempo que hay que esperar entre ataques
    /// </summary>
    public float attackRate;
    /// <summary>
    /// Variable auxiliar para calcular el attackRate
    /// </summary>
    private float auxRate;
    private Living playerLiving;
    void Start()
    {
        myAnimator = GetComponentInParent<Animator>();
        playerLiving = PlayerControls.instance.GetComponent<Living>();
        auxRate = 0f;
        
    }
    void Update()
    {
        if (auxRate < attackRate) 
        {
            auxRate += Time.deltaTime;
        }

        if (CanAttack)
            Attack();
        
    }
    /// <summary>
    /// Detecta una colision de netrada 
    /// </summary>
    /// <param name="other">se espera al player</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControls>()) 
        {
            CanAttack = true;
        }
    }
    /// <summary>
    /// Detecta que algo a salido del area de colisión
    /// </summary>
    /// <param name="other">se espera al player</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerControls>())
        {
            CanAttack = false;
        }

    }
    /// <summary>
    /// Realiza el ataque, hace el daño y la animacion
    /// </summary>
    private void Attack() 
    {
        if (auxRate >= attackRate) 
        {
            myAnimator.SetTrigger("Attack");
            MakeDamage();
            auxRate = 0f;
        }

    }
    /// <summary>
    /// Esta es la funcion que hace daño al jugador
    /// Se la llama desde la animacion de ataque (se debería llamar desde el animator)
    /// </summary>
    public void MakeDamage()
    {
        playerLiving.MakeDamage(damage);
    }
}