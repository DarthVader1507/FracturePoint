using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject TutorialScreen;
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ShowTutorial()
    {
        MainScreen.SetActive(false);
        TutorialScreen.SetActive(true);
    }
    public void HideTutorial()
    {
        MainScreen.SetActive(true);
        TutorialScreen.SetActive(false);
    }
}
