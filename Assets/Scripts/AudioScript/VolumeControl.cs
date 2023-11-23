using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        if (audioSource == null || volumeSlider == null)
        {
            Debug.LogError("Veuillez attribuer l'AudioSource et le Slider dans l'éditeur Unity.");
            return;
        }

        volumeSlider.value = audioSource.volume;

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float volume)
    {
        audioSource.volume = volume;
    }
}