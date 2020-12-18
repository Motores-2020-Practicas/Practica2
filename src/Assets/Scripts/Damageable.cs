using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    int currentDamage;
    public int maxDamage;

    private Vector2 initPos;
    private Quaternion initRot;
    private Transform tr;

    private void Start()
    {
        currentDamage = 0;
        tr = this.gameObject.GetComponent<Transform>();
        initPos = tr.position;
        initRot = tr.rotation;
    }

    public void MakeDamage()
    {
        currentDamage++;
        if (currentDamage >= maxDamage)
        {
            if (this.gameObject.tag == "enemy")
            {
                Destroy(this.gameObject);
            }
            else if (this.gameObject.tag == "Player") {
                Reset();
            }
        }
    }

    private void Reset()
    {
        tr.position = initPos;
        tr.rotation = initRot;
        currentDamage = 0;
    }
}
