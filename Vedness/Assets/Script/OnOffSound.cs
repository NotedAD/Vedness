using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffSound : MonoBehaviour
{
    public Slider slider;
    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
        slider.value = 0;
        slider.interactable = !slider.interactable;
    }
}
