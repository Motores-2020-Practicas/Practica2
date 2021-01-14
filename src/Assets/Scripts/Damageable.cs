using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    //Vida actual del GO
    int currentDamage;
    //Maximo de daño que puede recibir el GO
    public int maxDamage;

    //Vector que guarda la posicion inicial del GO
    private Vector2 initPos;
    //Quaternion que guarda la rotación inicial del GO
    private Quaternion initRot;
    //Transform del GO
    private Transform tr;
    //Singleton del GameManager
    private static GameManager instance;

    private void Start()
    {
        currentDamage = 0;
        tr = this.gameObject.GetComponent<Transform>();
        initPos = tr.position;
        initRot = tr.rotation;
        instance = GameManager.getInstance();
    }

    //Aplica el daño correspondiente al GO asociado a este script
    public void MakeDamage()
    {
        currentDamage++;
        if (currentDamage >= maxDamage)
        {
            if (this.gameObject.GetComponent<Enemy>())
            {
                Destroy(this.gameObject);
                this.gameObject.GetComponent<Enemy>().DestroyEnemy();

            }
            else if (this.gameObject.GetComponent<PlayerController>()) {
                Reset();
            }
        }
    }

    //Resetea la posicion del jugador en caso de tener vidas todavía
    private void Reset()
    {
        if (!instance.PlayerDestroyed())
        {
            tr.position = initPos;
            tr.rotation = initRot;
            currentDamage = 0;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
