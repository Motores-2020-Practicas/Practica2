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

    void Start()
    {
        instance = GameManager.getInstance();
        //En caso de que haya GM
        if (instance)
        {
            instance.AddEnemy();
        }
    }
}
