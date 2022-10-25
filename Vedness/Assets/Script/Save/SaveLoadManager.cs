using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    string filePath;
    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.vsave";
    }
    public void SaveGame()
    {

    }
    public void LoadGame()
    {

    }
}

[System.Serializable]
public class Save
{

}