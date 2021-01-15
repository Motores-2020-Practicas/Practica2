using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Publicas
    public int points;                      //Puntos que otorga el enemigo al morir

    //Privadas
    private static GameManager instance;    //Singleton del GameManager

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.getInstance();
        instance.AddEnemy();
    }

    //Elimina al enemigo y suma los puntos al jugador
    public void DestroyEnemy()
    {
        instance.EnemyDestroyed(points);
    }
}
