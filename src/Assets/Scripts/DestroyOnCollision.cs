using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        //Si el objeto con el que colisiona no es el muro entonces es el player o un enemigo
        //En tal caso, hace daño
        //WallLayer = 8 / BaseLayer = 9
        if (collision.gameObject.layer != 8 && collision.gameObject.layer != 9)
        {
            collision.gameObject.GetComponent<Damageable>().MakeDamage();
        }
    }
}
