using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    private GameObject BGMusicObject;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        instance = this;
        source.volume = VolumeSettings.Volume;
        BGMusicObject = GameObject.Find("BgSound");
        BGMusicObject.GetComponent<AudioSource>().volume = VolumeSettings.BGMusic / 4f;
        DontDestroyOnLoad(gameObject);
    }
    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main Menu")
        {
            Destroy(gameObject);
        }
    }
}
