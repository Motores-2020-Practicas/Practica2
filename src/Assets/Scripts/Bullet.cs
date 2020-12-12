using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocityScale;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * velocityScale * Time.deltaTime, 0);
    }

    public void SetDirection(Vector2 direction)
    {
        transform.up = direction;
    }
}
