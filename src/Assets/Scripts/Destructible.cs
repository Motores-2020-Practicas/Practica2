using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que gestiona la colisión de los 
/// objetos destruibles por las balas
/// </summary>
public class Destructible : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destruye el objeto cuando la bala le choca
        if (collision.gameObject.GetComponent<Bullet>()) {
            Destroy(gameObject);
        }
    }
}
