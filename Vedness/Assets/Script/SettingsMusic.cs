using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMusic : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetLevel(float sliderValue)
    {
        audioMixer.SetFloat("MusicGame", sliderValue);
    }

}
