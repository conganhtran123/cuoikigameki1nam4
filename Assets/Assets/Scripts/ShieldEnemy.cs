using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : Enemy
{
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private int scoreShieldEnemy = 20;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDamage(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDamage(stayDamage);
            }
        }
    }

    protected override void Die()
    {
        if (shieldObject != null)
        {
            GameObject shield = Instantiate(shieldObject, transform.position, Quaternion.identity);
            Destroy(shield, 10f);
        }
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scoreShieldEnemy);
        }
        base.Die();
    }
}
