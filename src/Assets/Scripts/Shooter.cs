using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que gestiona la lógica de 
/// los disparos de las entidades
/// </summary>
public class Shooter : MonoBehaviour
{
    //Public
    // Prefab de bala
    public GameObject bullet;
    // Indica si se dispara el tanque manual o automaticamente
    public bool autoShoot;
    // Cadencia de disparo, cuando es manual
    public float coolingDownSecs;
    // Cadencia de disparo, cuando es automatico
    public float shootCadenceSecs;

    //Private
    // Contador para poder volver a disparar
    private float timer;

    void Start()
    {
        timer = 0;
        if (autoShoot)
        {
            InvokeRepeating("ShootEnemy", 2.0f, shootCadenceSecs);
        }
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    // Dispara una bala
    /// <summary>
    /// Dispara una bala del jugador
    /// </summary>
    public void Shoot ()
    {
        if (timer <= 0)
        {
            GameObject bullet_;
            bullet_ = Instantiate(bullet, transform.position, Quaternion.identity);
            bullet_.GetComponent<Bullet>().SetDirection(transform.up);
            timer = coolingDownSecs;
        }
    }

    /// <summary>
    /// Dispara una bala que no es del jugador
    /// </summary>
    public void ShootEnemy() {
        GameObject bullet_;
        bullet_ = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet_.GetComponent<Bullet>().SetDirection(transform.up);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }
}
