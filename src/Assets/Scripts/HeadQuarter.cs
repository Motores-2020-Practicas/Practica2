using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadQuarter : MonoBehaviour
{
    //Sprite que aparece cuando el águila es destruido
    public Sprite destroyedEagle;
    //Sprite acutal del HeadQuarter
    private SpriteRenderer currentSprite;
    //Singleton del GameManager
    private static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.getInstance();
        currentSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Si el jugador entra en contacto con el HQ, gana el nivel
        if (collider.GetComponent<PlayerController>())
        {
            Vector3 basePosition = transform.position;
            collider.gameObject.transform.position = new Vector3(basePosition.x, basePosition.y, 1);
            instance.FinishLevel(true);
        }
        // Si una bala enemiga entra en contacto, pierde el nivel
        if (collider.gameObject.tag == "enemyBullet")
        {
            currentSprite.sprite = destroyedEagle;
            instance.FinishLevel(false);
        }
    }
}
