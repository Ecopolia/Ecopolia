using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        // Assurez-vous que l'AudioSource et le Slider sont référencés dans l'éditeur Unity
        if (audioSource == null || volumeSlider == null)
        {
            Debug.LogError("Veuillez attribuer l'AudioSource et le Slider dans l'éditeur Unity.");
            return;
        }

        // Définir la valeur initiale du Slider sur le volume actuel de l'AudioSource
        volumeSlider.value = audioSource.volume;

        // Ajouter un auditeur d'événements pour détecter les changements de valeur du Slider
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float volume)
    {
        // Ajuster le volume de l'AudioSource en fonction de la valeur du Slider
        audioSource.volume = volume;
    }
}