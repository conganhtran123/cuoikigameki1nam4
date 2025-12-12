using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : MonoBehaviour
{
    [SerializeField] private float shieldAmount = 20f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Shield(); // Heal the player by 20 health points
                Destroy(gameObject); // Destroy the healing object after use
            }
        }
    }
}
