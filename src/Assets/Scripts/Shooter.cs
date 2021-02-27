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
    public float cadenceManual;
    // Cadencia de disparo, cuando es automatico
    public float cadenceAuto;

    //Private
    // Contador para poder volver a disparar
    private float timer;
    //Referente al padre de la bala enemiga
    private Transform parentBullet;

    void Start()
    {
        timer = 0;
        if (autoShoot)
        {
            parentBullet = GameObject.Find("Enemies").GetComponent<Transform>();
            InvokeRepeating("ShootEnemy", 2.0f, cadenceAuto);
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
            timer = cadenceManual;
        }
    }

    /// <summary>
    /// Dispara una bala que no es del jugador
    /// </summary>
    public void ShootEnemy() {
        GameObject bullet_;
        bullet_ = Instantiate(bullet, transform.position, Quaternion.identity, parentBullet);
        bullet_.GetComponent<Bullet>().SetDirection(transform.up);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }
}
