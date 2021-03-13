using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que gestiona la lógica del input
/// del jugador
/// </summary>
public class PlayerController : MonoBehaviour {
    //Publicas
    //Velocidad del player
    public float velocityScale;

    //Privadas  
    //Guarda el componente Shooter para disparar
    private Shooter cannon;

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
        if (Input.GetButton("Jump"))
        {
            cannon.Shoot();
        }
    }
}
