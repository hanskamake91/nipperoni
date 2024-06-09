using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healthController : MonoBehaviour
{

    // Creating variables for checking what is/are enemies, is player in contact with enemy and cooldown when player can take damage
    public Transform enemyCheck;
    public LayerMask whatIsEnemy;
    private bool takingDamage;

    public float damageCooldown = 0.9f;

    private int maxHP = 3;
    public Text hpText;

    public Rigidbody2D rb2D;
    public GameObject enemy;
    public float vertKnockForce = 1f;
    public float horizKnockForce = 1f;


    void Start()
    {
        // Show player HP when the game starts
        hpText.text += maxHP;
    }


    // Update is called once per frame
    void Update()
    {
        // First checking if in contact with enemy, and if true and cooldown is off then player takes damage which then is set to cooldown
        takingDamage = Physics2D.OverlapCircle(enemyCheck.position, 0.5f, whatIsEnemy);

        if (takingDamage && damageCooldown >= 0.9f)
        {
            // TODO: add force to player when taking damage
            damageCooldown = 0.0f;
            Debug.Log("Taking damage");
            maxHP -= 1;
            hpText.text = "HP: " + maxHP;
            rb2D.AddForce(Vector2.up * vertKnockForce);

            if (rb2D.position.x < enemy.transform.position.x)
            {
                rb2D.AddForce(Vector2.left * horizKnockForce);
                
            } else 
            {
                rb2D.AddForce(Vector2.right * horizKnockForce);
            }
        }

        // Managing cooldown time 0-3
        if (damageCooldown <= 0.9f)
        {
            damageCooldown += Time.deltaTime;
        }
    }
}
