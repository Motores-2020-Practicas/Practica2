using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocityScale; //Velocidad de la bala

    public void SetDirection(Vector2 direction)
    {
        transform.up = direction;
        this.GetComponent<Rigidbody2D>().velocity = direction * velocityScale;
    }
}
