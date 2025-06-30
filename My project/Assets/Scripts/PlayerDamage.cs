using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float damage; // Damage to be applied to the player when they collide with this object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
