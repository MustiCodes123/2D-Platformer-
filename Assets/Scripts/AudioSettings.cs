using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider volumeSlider;


    void Start()
    {

        volumeSlider.value = AudioListener.volume;


    }
    public void onVolumeSliderChanged()
    {
        AudioListener.volume = volumeSlider.value;

    }
    // Update is called once per frame
    void Update()
    {

    }

}
