using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destruye el objeto cuando la bala le choca
        if (collision.gameObject.tag == "bala") {
            Destroy(this.gameObject);
        }
    }
}
