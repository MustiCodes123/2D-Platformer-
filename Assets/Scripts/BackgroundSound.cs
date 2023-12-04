using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public AudioClip backgroundAudioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundAudioClip;

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on this GameObject.");
            return;
        }

        if (backgroundAudioClip == null)
        {
            Debug.LogError("No audio clip assigned to the BackgroundSound script.");
            return;
        }

        PlayBackgroundSound();
    }

    private void PlayBackgroundSound()
    {
        // Check if an AudioListener is present in the scene
        AudioListener audioListener = FindObjectOfType<AudioListener>();
        if (audioListener == null)
        {
            Debug.LogWarning("No AudioListener found in the scene. Adding a default AudioListener.");
            Camera.main.gameObject.AddComponent<AudioListener>();
        }

        // Play the audio in a loop
        audioSource.loop = true;
        audioSource.Play();
    }
}
