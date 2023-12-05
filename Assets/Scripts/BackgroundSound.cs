using Unity.VisualScripting;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public AudioClip[] clips;

    public Transform player;

    public AudioSource audioSource;

    bool playing = false;
    int index = 0;
    public int buffer = 120;
    private void Start()
    {
        //audioSource = gameObject.AddComponent<AudioSource>();
        int temp = (int)(player.position.y) / 12;
        index = temp;
    }

    void Update()
    {

        if (!playing)
            PlayBackgroundSound();
        else
        {
            int temp = (int)(player.position.y) / 12;
            if (index != temp)
            {
                buffer--;
                if (buffer <= 0)
                {
                    index = temp;
                    playing = false;
                    audioSource.Stop();
                    buffer = 120;
                }

            }
            else
            {
                buffer = 120;
            }
        }

    }

    private void PlayBackgroundSound()
    {
        audioSource.clip = clips[index];
        audioSource.loop = true;
        audioSource.Play();
        playing = true;
    }
}
