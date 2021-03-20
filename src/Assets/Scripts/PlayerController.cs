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
        if (Input.GetButton("Horizontal"))
        {
            transform.up = Vector2.right * Input.GetAxis("Horizontal");
            transform.Translate(transform.up * velocityScale * Time.deltaTime, 0);
        }
        else if (Input.GetButton("Vertical"))
        {
            transform.up = Vector2.up * Input.GetAxis("Vertical");
            transform.Translate(transform.up * velocityScale * Time.deltaTime, 0);
        }

        if (Input.GetButton("Jump"))
        {
            cannon.Shoot();
        }
    }
}
