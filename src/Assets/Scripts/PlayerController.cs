using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Publicas
    public float velocityScale; //Velocidad del player

    //Privadas  
    private Shooter cannon;     //Referencia al componente shooter para poder disparar

    void Start()
    {
        cannon = GetComponentInChildren<Shooter>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.up = Vector2.left;    // (-1, 0)
            transform.Translate(transform.up * velocityScale * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.up = Vector2.right;   // (1, 0)
            transform.Translate(transform.up * velocityScale * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.up = Vector2.up;      // (0, 1)
            transform.Translate(transform.up * velocityScale * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.up = Vector2.down;    // (0, -1)
            transform.Translate(transform.up * velocityScale * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cannon.Shoot();
        }
    }
}
