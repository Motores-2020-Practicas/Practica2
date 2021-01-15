using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script asociado a los muros destruibles y a las balas (del jugador y de los enemigos)
public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //En cualquier caso destruye el objeto
        Destroy(this.gameObject);

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
