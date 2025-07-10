using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider bgMusicSlider;
    [SerializeField] private Text volumeText;
    [SerializeField] private Text bgMusicText;
    void Start()
    {
        // Set sliders to values from static class
        volumeSlider.value = VolumeSettings.Volume;
        bgMusicSlider.value = VolumeSettings.BGMusic;
        volumeText.text = $"{volumeSlider.value * 100:F0}%";
        bgMusicText.text = $"{bgMusicSlider.value * 100:F0}%";

        // Listen for changes
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        bgMusicSlider.onValueChanged.AddListener(OnBGMusicChanged);
    }

    private void OnVolumeChanged(float value)
    {
        VolumeSettings.Volume = value;
        volumeText.text = $"{value * 100:F0}%";
    }

    private void OnBGMusicChanged(float value)
    {
        VolumeSettings.BGMusic = value;
        bgMusicText.text = $"{value * 100:F0}%";
    }
}