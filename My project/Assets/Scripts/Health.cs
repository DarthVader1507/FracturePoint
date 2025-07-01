using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [Header("Invulnerability Settings")]
    [SerializeField] private float invulnerabilityDuration; // Duration of invulnerability after taking damage
    private int invulnerabilityFrames = 3; // Number of frames to be invulnerable after taking damage
    private float startingHealth = 0.5f;
    public static float currentHealth = 0.5f;//To carry the value across scenes
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private Image totalHealthBar;
    private Animator anim;

    private SpriteRenderer spriteRenderer;
    private CountdownScript countdownScript;
    [Header ("Death Sound")]
    [SerializeField]private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0.1f)//Decimal point in Unity is not accurate, so we use 0.1f as a threshold
        {
            //Player lives,but is hurt
            anim.SetTrigger("Hurt");
            StartCoroutine(VulnerabilityCoroutine()); // Start invulnerability coroutine
            SoundManager.instance.PlaySound(hurtSound); // Play hurt sound
        }
        else
        {
            //Player dies
            anim.SetTrigger("Die");
            countdownScript.gameStarted = false; // Stop the game when player dies
            currentHealth = 0; // Ensure health does not go below zero
            GetComponent<PlayerMovement>().enabled = false; // Disable player movement
            SoundManager.instance.PlaySound(deathSound); // Play death sound
        }
        currentHealthBar.fillAmount = currentHealth; // Update health bar to reflect death
    }
    private void Awake()
    {
        currentHealthBar.fillAmount = currentHealth;
        countdownScript = FindObjectOfType<CountdownScript>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private IEnumerator VulnerabilityCoroutine()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true); // Ignore collision with enemies while invulnerable
        for (int i = 0; i < invulnerabilityFrames; i++)
        {
            // Flash the player sprite to indicate invulnerability
            spriteRenderer.color = new Color(1f, 0, 0, 0.5f); // Set to semi-transparent
            yield return new WaitForSeconds(invulnerabilityDuration / (2 * invulnerabilityFrames)); // Flash every few seconds
            spriteRenderer.color = Color.white;// Reset to normal color
            yield return new WaitForSeconds(invulnerabilityDuration / (2 * invulnerabilityFrames)); // Wait before next flash
        }
        Physics2D.IgnoreLayerCollision(10, 11, false); // Re-enable collision
    }
    public void Heal(float healAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, startingHealth);
        currentHealthBar.fillAmount = currentHealth; // Update health bar to reflect healing
    }
}

