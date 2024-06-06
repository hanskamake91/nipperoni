using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{

    public Transform enemyCheck;
    public LayerMask whatIsEnemy;
    private bool takingDamage;

    public float damageCooldown = 0.8f;


    // Update is called once per frame
    void Update()
    {
        takingDamage = Physics2D.OverlapCircle(enemyCheck.position, 0.5f, whatIsEnemy);

        if (takingDamage)
        {
            Debug.Log("Taking damage");
        }
    }
}
