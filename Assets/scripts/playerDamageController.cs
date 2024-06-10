using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerDamageController : MonoBehaviour
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
    public float vertKnockForce = 50f;
    public float horizKnockForce = 50f;

    public characterController charController;
    public float moveEnableTimer = 0.7f;


    void Start()
    {
        // Show player HP when the game starts
        hpText.text += maxHP;
        charController.moveEnabled = true;
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
            moveEnableTimer = 0.0f;
            Debug.Log("Taking damage");
            maxHP -= 1;
            hpText.text = "HP: " + maxHP;
            rb2D.AddForce(Vector2.up * vertKnockForce, ForceMode2D.Impulse);

            if (rb2D.position.x < enemy.transform.position.x)
            {
                charController.moveEnabled = false;
                rb2D.AddForce(horizKnockForce * Vector2.left, ForceMode2D.Impulse);
                Debug.Log("KNOCKBACK LEFT");
            } else 
            {
                charController.moveEnabled = false;
                rb2D.AddForce(horizKnockForce * Vector2.right, ForceMode2D.Impulse);
                Debug.Log("KNOCKBACK RIGHT");
            }
        }

        // Managing cooldown time
        if (damageCooldown <= 0.9f)
        {
            damageCooldown += Time.deltaTime;
        }

        // Managing move enabler
        if (moveEnableTimer <= 0.7)
        {
            moveEnableTimer += Time.deltaTime;
        }

        if (moveEnableTimer >= 0.7)
        {
            charController.moveEnabled = true;
        }
    }
}
