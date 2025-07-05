using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject TutorialScreen;
    [SerializeField] private GameObject ControlsScreen;
    private void Start(){
        MainScreen.SetActive(true);
        TutorialScreen.SetActive(false);
        ControlsScreen.SetActive(false);
    }
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
        ControlsScreen.SetActive(false);
    }
    public void HideTutorial()
    {
        MainScreen.SetActive(true);
        TutorialScreen.SetActive(false);
        ControlsScreen.SetActive(false);
    }
    public void ShowControls()
    {
        MainScreen.SetActive(false);
        TutorialScreen.SetActive(false);
        ControlsScreen.SetActive(true);
    }
    public void HideControls()
    {
        MainScreen.SetActive(false);
        TutorialScreen.SetActive(true);
        ControlsScreen.SetActive(false);
    }
}
