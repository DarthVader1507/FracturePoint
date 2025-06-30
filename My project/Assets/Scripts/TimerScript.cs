using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
    [SerializeField]private Text timerText;
    private float timeLeft;
    private CountdownScript countdownScript;
    [SerializeField] private GameObject Level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            timeLeft = 20f; // Set the timer for Level 1
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            timeLeft = 40f; // Set the timer for Level 2
        }
        else if(SceneManager.GetActiveScene().name == "Level3")
        {
            timeLeft = 60f; // Set the timer for Level 3
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
}
