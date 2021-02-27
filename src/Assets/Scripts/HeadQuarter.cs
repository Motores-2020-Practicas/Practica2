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
        instance = GameManager.getInstance();
        currentSprite_R = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Si el jugador entra en contacto con el HQ, gana el nivel
        if (collider.GetComponent<PlayerController>())
        {
            //Vector3 basePosition = transform.position;

            GameObject player = collider.gameObject;
            Instantiate(player, transform.position, Quaternion.identity, transform);
            Destroy(collider);
            //collider.gameObject.transform.position = new Vector3(basePosition.x, basePosition.y, 1);
            instance.FinishLevel(true);
        }
        // Si una bala entra en contacto, pierde el nivel
        if (collider.gameObject.GetComponent<Bullet>())
        {
            currentSprite_R.sprite = destroyedEagle;
            instance.FinishLevel(false);
        }
    }
}
