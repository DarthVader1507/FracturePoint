using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownScript : MonoBehaviour
{
    private int countdownTime = 3;
    public Text countdownDisplay;
    
    public bool gameStarted = false;
    [SerializeField] private AudioClip goSound;
    private void Start()
    {
        gameStarted = false;
        countdownDisplay.gameObject.SetActive(true);
        // Start the countdown coroutine
        StartCoroutine(WaitAndStart());
    }
    private IEnumerator WaitAndStart()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart()
    {
        //This is a coroutine which is a standard C# function which can be executed periodically using yield statement
        while (countdownTime > 0)
        {
            countdownDisplay.color = Color.white;
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.text = "GO!";
        SoundManager.instance.PlaySound(goSound);
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
        gameStarted = true;
    }
}
