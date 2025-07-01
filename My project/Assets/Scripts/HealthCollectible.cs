using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private float healthValue = 0.1f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (Health.currentHealth >= 0.1f)
            {
                playerHealth.Heal(healthValue); // Heal the player
                gameObject.SetActive(false); // Deactivate the collectible after healing
            }
        }
    }
}
