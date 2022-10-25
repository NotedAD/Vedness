using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    private GameObject[] characters;
    public int index;
    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        characters = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in characters)
        {
            go.SetActive(false);
        }

        if (characters[index])
        {
            characters[index].SetActive(true);
        }
    }
    public void Solider()
    {
            index = 0;
    }

    public void Archer()
    {
            index = 1;
    }
    public void Mag()
    {
            index = 2;
    }

    public void StartScene()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        if(index == 0)
        {
            characters[1].SetActive(false);
            characters[2].SetActive(false);
        }
        else if (index == 1)
        {
            characters[0].SetActive(false);
            characters[2].SetActive(false);
        }
        else if (index == 2)
        {
            characters[0].SetActive(false);
            characters[1].SetActive(false);
        }
        SceneManager.LoadScene("MainGame");
    }
        
}
