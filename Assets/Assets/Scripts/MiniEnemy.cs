using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemy : Enemy
{
    [SerializeField] private int scoreMiniEnemy = 5;
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
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scoreMiniEnemy);
        }
        base.Die();
    }
}
