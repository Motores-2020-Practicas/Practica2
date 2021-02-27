using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que gestiona la dirección que va
/// a tener la bala una vez ha sido creada
/// </summary>
public class Bullet : MonoBehaviour
{
    //Velocidad de la bala
    public float velocityScale;

    /// <summary>
    /// Asigna una dirección a la bala
    /// </summary>
    public void SetDirection(Vector2 direction)
    {
        transform.up = direction;
        GetComponent<Rigidbody2D>().velocity = direction * velocityScale;
    }
}
