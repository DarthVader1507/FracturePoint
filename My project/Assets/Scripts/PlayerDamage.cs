using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float damage; // Damage to be applied to the player when they collide with this object
    [SerializeField] private AudioClip damageSound; // Sound to play when the player takes damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(damageSound);
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
