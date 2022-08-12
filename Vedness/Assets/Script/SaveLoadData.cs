using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadData : MonoBehaviour
{
    public readonly string AudioPref = "AudioPref";
    public Slider slider;
    public AudioSource audio;
    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(AudioPref, SoundVolumeControllerComponent.perd);
    }
    public void LoadSoundSetting()
    {
        audio = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey(AudioPref))
        {
            slider.value = PlayerPrefs.GetFloat(AudioPref);
            audio.volume = PlayerPrefs.GetFloat(AudioPref);
        }
    }
}
