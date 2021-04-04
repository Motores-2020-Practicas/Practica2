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

    private void Start()
    {
        //Cuando se crea se empieza a mover en su eje Y
        GetComponent<Rigidbody2D>().velocity = transform.up * velocityScale;
    }

    /// <summary>
    /// Asigna una dirección a la bala
    /// </summary>
    public void SetDirection(Vector2 direction)
    {
        transform.up = direction;
    }
}
