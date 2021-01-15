using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //Public
    // Prefab de bala
    public GameObject bullet;
    // Cantidad de segundos a esperar para poder disparar de nuevo
    public float coolingDownSecs;
    // Indica si se dispara el tanque manual o automaticamente
    public bool autoShoot;
    // Cadencia de disparo automatico
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

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    // Dispara una bala
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

    // Dispara una bala enemiga
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
