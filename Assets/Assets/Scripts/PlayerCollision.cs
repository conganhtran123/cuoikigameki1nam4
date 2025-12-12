using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private float healAmount = 20f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private GameObject gameWin;

    
    private void Start()
    {
        gameWin.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HpObject"))
        {
            Player player = GetComponent<Player>();
            if (player != null)
            {
                player.Heal(healAmount); // Heal the player by 20 health points
                AudioManager.Instance.PlayEnergySound();
                Destroy(other.gameObject);
            }
            
        }

        if (other.CompareTag("EnemyBullet"))
        {
            Player player = GetComponent<Player>();
            if (player != null)
            {
                player.takeDamage(damage);
                Destroy(other.gameObject);
            }
            
        }
        if (other.CompareTag("ShieldObject"))
        {
            Player player = GetComponent<Player>();
            if (player != null)
            {
                player.StartCoroutine(player.Shield());
                Destroy(other.gameObject);
                AudioManager.Instance.PlayEnergySound();
            }
            
        }
        if (other.CompareTag("Checkpoint"))
        {
            Player player = GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Checkpoint reached!");
                Destroy(other.gameObject);
                gameWin.SetActive(true);
            }
        }
    }
}
