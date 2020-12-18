using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //Public
    public GameObject bullet;
    public float coolingDownSecs;
    public bool autoShoot;
    public float shootCadenceSecs;

    //Private
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
