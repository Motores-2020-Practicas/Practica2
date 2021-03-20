using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase asociada a los GO que pueden sufrir daño
/// de manera que gestiona la vida que le queda y si
/// debe ser destruido o no
/// </summary>
public class Damageable : MonoBehaviour
{
    //Publicas
    //Maximo de daño que puede recibir el GO
    public int maxDamage;

    //Privadas
    //Vida actual del GO
    private int currentDamage;
    //Puntos que otorga el enemigo al morir
    private int points;
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
        tr = gameObject.GetComponent<Transform>();
        initPos = tr.position;
        initRot = tr.rotation;
        instance = GameManager.getInstance();
    }

    /// <summary>
    /// Aplica el daño al GO. 
    /// Después comprueba si es Enemigo o Player
    /// para destruir o hacer un reset.
    /// </summary>
    public void MakeDamage()
    {
        currentDamage++;
        if (currentDamage >= maxDamage)
        {
            if (gameObject.GetComponent<Enemy>())
            {
                points = 100;
                DestroyEnemy();
            }
            else if (gameObject.GetComponent<PlayerController>())
            {
                points = 0;
                Reset();
            }
        }
    }

    /// <summary>
    /// Si el jugador tiene vidas, reinicia la posición
    /// si no, entonces destruye al player
    /// </summary>
    private void Reset()
    {
        //En caso de que no haya GM se destruye el objeto
        if (instance && !instance.PlayerDestroyed())
        {
            tr.position = initPos;
            tr.rotation = initRot;
            currentDamage = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Elimina al enemigo y suma los puntos al jugador
    /// </summary>
    private void DestroyEnemy()
    {
        Destroy(gameObject);
        if (instance)
        {
            instance.EnemyDestroyed(points);
        }
    }
}
