using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Velocidad de la bala
    public float velocityScale;

    public void SetDirection(Vector2 direction)
    {
        transform.up = direction;
        this.GetComponent<Rigidbody2D>().velocity = direction * velocityScale;
    }
}
