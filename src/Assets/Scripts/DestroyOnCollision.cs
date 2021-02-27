using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que gestiona la destrucción
/// del GO en caso de haber sido colisionado
/// </summary>
public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //En cualquier caso destruye el objeto
        Destroy(gameObject);

        //Si el objeto colisionado tiene asociado el componente, entonces aplica el daño
        Damageable dmg = collision.gameObject.GetComponent<Damageable>();
        if (dmg)
        {
            dmg.MakeDamage();
            //Sirve para que el player no se desplace cuando el choca una bala enemiga
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
    }
}
