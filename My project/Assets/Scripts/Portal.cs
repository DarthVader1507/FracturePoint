using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]private GameObject victoryPanel;
    [SerializeField]private AudioClip victorySound;
    private CountdownScript countdownScript;
    private Health healthScript;
    public bool hasWon = false;
    private void Start()
    {
        // Find the CountdownScript in the scene
        countdownScript = FindObjectOfType<CountdownScript>();
        if (countdownScript == null)
        {
            Debug.LogError("CountdownScript not found in the scene.");
        }

        // Ensure the victory panel is initially inactive
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
        hasWon = false;
        healthScript = FindObjectOfType<Health>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Logic to teleport the player to another location
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                if (healthScript != null && healthScript.isDead)
                {
                    // If the player is dead, do not proceed to victory
                    return;
                }
                // Show victory panel and play sound
                countdownScript.gameStarted = false; // Stop the countdown
                Time.timeScale = 0; // Pause the game
                victoryPanel.SetActive(true);
                SoundManager.instance.PlaySound(victorySound);
                hasWon = true;
            }
        }
    }
}
