using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PauseScript : MonoBehaviour
{
    public GameObject pausePanel;
    private Portal portalScript;
    private Health healthScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);
        portalScript = FindObjectOfType<Portal>();
        healthScript = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !portalScript.hasWon && !healthScript.isDead)
        {
            if (pausePanel.activeSelf || Time.timeScale == 0)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        GameObject bgMusic = GameObject.Find("BgSound");
        if (bgMusic != null)
        {
            Destroy(bgMusic);
        }
        // Reset player state
        Health.currentHealth = 0.5f;
        portalScript.hasWon = false;
        healthScript.isDead = false;
        PlayerMovement.jumpBoost = 0;
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
    public void Exit()
    {
        GameObject bgMusic = GameObject.Find("BgSound");
        if (bgMusic != null)
        {
            Destroy(bgMusic);
        }
        // Reset player state
        Health.currentHealth = 0.5f;
        portalScript.hasWon = false;
        healthScript.isDead = false;
        PlayerMovement.jumpBoost = 0;
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}