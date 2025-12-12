using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HpEnemy : Enemy
{
    [SerializeField] private GameObject hpObject;
    [SerializeField] private int scoreHpEnemy = 20;
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
        if (hpObject != null)
        {
            GameObject hp = Instantiate(hpObject, transform.position, Quaternion.identity);
            Destroy(hp, 10f);
        }
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scoreHpEnemy);
        }
        base.Die();
    }
}
