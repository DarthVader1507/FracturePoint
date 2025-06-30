using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class TimerScript : MonoBehaviour
{
    [SerializeField] private Text timerText;
    private float timeLeft;
    private CountdownScript countdownScript;
    [SerializeField] private GameObject Level;
    [SerializeField] private SpriteRenderer doorSpriteRenderer1;
    [SerializeField] private SpriteRenderer doorSpriteRenderer2;
    [SerializeField] private SpriteRenderer doorSpriteRenderer3;
    [SerializeField] private SpriteRenderer doorSpriteRenderer4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            timeLeft = 20f; // Set the timer for Level 1
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            timeLeft = 40f; // Set the timer for Level 2
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            timeLeft = 60f; // Set the timer for Level 3
            SetDoorSprites(false); // Disable the door sprites at the start of Level 3
            StartCoroutine(DoorTrap()); // Start the repeating trap
            Debug.Log("Starting DoorTrap coroutine for Level 3");
        }
        countdownScript = FindObjectOfType<CountdownScript>();
        timerText.text = timeLeft.ToString("F2");
    }
    // Update is called once per frame
    void Update()
    {
        if (countdownScript.gameStarted == false)
        {
            return; // Exit if the game has not started
        }
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString("F2");
            if (timeLeft < 5)
            {
                timerText.color = Color.red; // Change text color to red when time is less than 5 seconds
            }
            else
            {
                timerText.color = Color.white; // Reset text color to white when time is above 5 seconds
            }
        }
        else
        {
            timeLeft = 0;
            timerText.text = "Time's up!";
            Level.SetActive(false); // Deactivate the level when time is up
        }
    }
    private IEnumerator DoorTrap()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); // Wait for 1 second before activating the door trap
            SetDoorSprites(true); // Enable the door sprites when the trap is activated
            SetDoorTraps(true); // Enable the door colliders to allow player interaction
            yield return new WaitForSeconds(2f); // Wait for 1 second before deactivating the level
            SetDoorSprites(false); // Disable the door sprites after the trap is activated
            SetDoorTraps(false); // Disable the door colliders to prevent player interaction
        }
    }
    private void SetDoorSprites(bool enabled)
    {
        doorSpriteRenderer1.enabled = enabled;
        doorSpriteRenderer2.enabled = enabled;
        doorSpriteRenderer3.enabled = enabled;
        doorSpriteRenderer4.enabled = enabled;

    }
    // Add this method to your TimerScript class

    private void SetDoorTraps(bool activate)
    {
        Debug.Log("SetDoorTraps called: " + activate);
        var doors = new Door[]
        {
        doorSpriteRenderer1.gameObject.GetComponentInParent<Door>(),
        doorSpriteRenderer2.gameObject.GetComponentInParent<Door>(),
        doorSpriteRenderer3.gameObject.GetComponentInParent<Door>(),
        doorSpriteRenderer4.gameObject.GetComponentInParent<Door>()
        };

        foreach (var door in doors)
        {
            if (door != null)
            {
                if (activate)
                    door.ActivateTrap();
                else
                    door.DeactivateTrap();
            }
        }
    }
}