using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject TutorialScreen;
    [SerializeField] private GameObject ControlsScreen;
    [SerializeField] private GameObject SettingsScreen;
    [SerializeField] private AudioClip clickSound;
    private void Start()
    {
        MainScreen.SetActive(true);
        TutorialScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
    }
    public void Play()
    {
        SoundManager1.Instance.PlaySound(clickSound);
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        SoundManager1.Instance.PlaySound(clickSound);
        Application.Quit();
    }
    public void ShowTutorial()
    {
        SoundManager1.Instance.PlaySound(clickSound);
        MainScreen.SetActive(false);
        TutorialScreen.SetActive(true);
        ControlsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
    }
    public void HideTutorial()
    {
        SoundManager1.Instance.PlaySound(clickSound);
        MainScreen.SetActive(true);
        TutorialScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
    }
    public void ShowControls()
    {
        SoundManager1.Instance.PlaySound(clickSound);
        MainScreen.SetActive(false);
        TutorialScreen.SetActive(false);
        ControlsScreen.SetActive(true);
        SettingsScreen.SetActive(false);
    }
    public void HideControls()
    {
        SoundManager1.Instance.PlaySound(clickSound);
        MainScreen.SetActive(false);
        TutorialScreen.SetActive(true);
        ControlsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
    }
    public void ShowSettings()
    {
        SoundManager1.Instance.PlaySound(clickSound);
        MainScreen.SetActive(false);
        TutorialScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }
    public void HideSettings()
    {
        SoundManager1.Instance.PlaySound(clickSound);
        MainScreen.SetActive(true);
        TutorialScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        SettingsScreen.SetActive(false);
    }
}
