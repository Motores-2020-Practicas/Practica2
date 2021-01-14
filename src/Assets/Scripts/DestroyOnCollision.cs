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
        if (collision.gameObject.GetComponent<Damageable>())
        {
            collision.gameObject.GetComponent<Damageable>().MakeDamage();
        }
    }
}
