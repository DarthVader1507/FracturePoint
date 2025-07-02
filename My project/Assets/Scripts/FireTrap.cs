using UnityEngine;
using System.Collections;
public class FireTrap : MonoBehaviour
{
    [Header("FireTrap Settings")]
    [SerializeField] private float damage;
    [SerializeField] private AudioClip activationSound;
    [Header("FireTrap Timers")]
    [SerializeField] private float activeDuration;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool isActive;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            StartCoroutine(ActivateTrap(other));
        }
    }
    private IEnumerator ActivateTrap(Collider2D other)
    {
        isActive = true;
        anim.SetBool("Active", isActive);
        SoundManager.instance.PlaySound(activationSound);
        other.GetComponent<Health>().TakeDamage(damage);
        yield return new WaitForSeconds(activeDuration);
        isActive = false;
        anim.SetBool("Active", isActive);
    }
}
