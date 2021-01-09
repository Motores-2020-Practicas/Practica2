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
    private static GameManager instance;

    private void Start()
    {
        currentDamage = 0;
        tr = this.gameObject.GetComponent<Transform>();
        initPos = tr.position;
        initRot = tr.rotation;
        instance = GameManager.getInstance();
    }

    public void MakeDamage()
    {
        currentDamage++;
        if (currentDamage >= maxDamage)
        {
            if (this.gameObject.GetComponent<Enemy>())
            {
                Destroy(this.gameObject);
                this.gameObject.GetComponent<Enemy>().DestroyEnemy();

            }
            else if (this.gameObject.GetComponent<PlayerController>()) {
                Reset();
            }
        }
    }

    private void Reset()
    {
        if (!instance.playerDestroyed())
        {
            tr.position = initPos;
            tr.rotation = initRot;
            currentDamage = 0;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
