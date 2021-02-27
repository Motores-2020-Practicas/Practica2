using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que gestiona la destrucción de 
/// un enemigo y la suma de puntos al morir
/// </summary>
public class Enemy : MonoBehaviour
{
    //Singleton del GameManager
    private static GameManager instance;    
    //Puntos que otorga el enemigo al morir
    private int points;

    void Start()
    {
        points = 100;
        instance = GameManager.getInstance();
        instance.AddEnemy();
    }

    /// <summary>
    /// Elimina al enemigo y suma los puntos al jugador
    /// </summary>
    public void DestroyEnemy()
    {
        instance.EnemyDestroyed(points);
    }
}
