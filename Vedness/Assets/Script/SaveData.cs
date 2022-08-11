using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public readonly string SliderPref = "SliderPref";
    public readonly string AudioPref = "AudioPref";
    public Slider musicSlider;
    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(SliderPref, musicSlider.value);
        PlayerPrefs.SetFloat(AudioPref, SoundVolumeControllerComponent.perd);
    }

}
