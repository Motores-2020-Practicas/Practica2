using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public float coolingDownSecs;

    private float timer;

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Shoot (Vector2 direction)
    {
        if (timer <= 0)
        {
            GameObject bullet_;
            bullet_ = Instantiate(bullet, transform.position, Quaternion.identity);
            bullet_.GetComponent<Bullet>().SetDirection(direction);
            timer = coolingDownSecs;
        }
    }
}
