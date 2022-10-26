using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    public float fps;
    public Text fpsText;

    void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;
        fpsText.text = "FPS: " + (int)fps;
    }
}
