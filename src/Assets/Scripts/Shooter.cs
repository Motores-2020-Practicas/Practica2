using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //Public
    public GameObject bullet;       // Prefab de bala
    public float coolingDownSecs;   // Cantidad de segundos a esperar para poder disparar de nuevo
    public bool autoShoot;          // Indica si se dispara el tanque manual o automaticamente
    public float shootCadenceSecs;  // Cadencia de disparo automatico

    //Private
    private float timer;            // Contador para poder volver a disparar
    private Transform parentBullet;  //Referente al padre de la bala enemiga

    void Start()
    {
        timer = 0;
        if (autoShoot)
        {
            parentBullet = GameObject.Find("Enemies").GetComponent<Transform>();
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
        bullet_ = Instantiate(bullet, transform.position, Quaternion.identity, parentBullet);
        bullet_.GetComponent<Bullet>().SetDirection(transform.up);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }
}
