using UnityEngine;

public class SoundManager1 : MonoBehaviour
{
    public static SoundManager1 Instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        Instance = this;
    }
    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
