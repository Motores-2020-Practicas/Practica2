using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points;
    private static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.getInstance();
        instance.AddEnemy();
        Debug.Log("ENEMIGO AÑADIDO\n");
    }

    public void DestroyEnemy()
    {
        instance.EnemyDestroyed(points);
    }
}
