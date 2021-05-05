using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que gestiona la lógica del HeadQuarter
/// </summary>
public class HeadQuarter : MonoBehaviour
{
    //Publicas
    //Guarda el sprite del HeadQuarter cuando muere
    public Sprite destroyedEagle;

    //Privadas
    //Guarda el sprite renderer actual del HeadQuarter
    private SpriteRenderer currentSprite_R;
    //Singleton del GameManager
    private static GameManager instance;

    void Start()
    {
        instance = GameManager.GetInstance();
        currentSprite_R = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Se desactiva el componente Collider de HQ
        //para que no le afecten las balas
        //en caso de terminar el nivel
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        //Referencia al PlayerController
        PlayerController playerCont = collision.gameObject.GetComponent<PlayerController>();

        // Si el jugador entra en contacto con el HQ, gana el nivel
        if (playerCont)
        {
            GameObject player = collision.gameObject;
            Destroy(collision.gameObject);
            Instantiate(player, transform.position, Quaternion.identity);
            instance.FinishLevel(true);
        }
        // Si una bala entra en contacto, pierde el nivel
        else if (collision.gameObject.GetComponent<Bullet>())
        {
            currentSprite_R.sprite = destroyedEagle;
            instance.FinishLevel(false);
        }
    }
}
