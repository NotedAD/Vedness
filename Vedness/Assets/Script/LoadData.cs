using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    public readonly string SliderPref = "SliderPref";
    public readonly string AudioPref = "AudioPref";
    public Slider slider;
    [Header("Components")]
    [Tooltip("Audio Source Does Òot Connect Automatically")]
    [SerializeField] private new AudioSource audio;
    [Header("Tags")]
    [Tooltip("Volume Control Slider Tag")]
    [SerializeField] private string SliderTag;
    public void LoadSoundSetting()
    {
        GameObject SliderObj = GameObject.FindWithTag(this.SliderTag);
        if (PlayerPrefs.HasKey(SliderPref)&& PlayerPrefs.HasKey(AudioPref))
        {
            if (SliderObj != null)
            {
                this.audio = SliderObj.GetComponent<AudioSource>();
                slider.value = PlayerPrefs.GetFloat(SliderPref);
                audio.volume = PlayerPrefs.GetFloat(AudioPref);
            }
        }
    }
}
