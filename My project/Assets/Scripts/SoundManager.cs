using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
