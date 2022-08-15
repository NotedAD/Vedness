using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

    //Scene MainMenu
    static int scene;
    public string quitTag;
    private GameObject quitObj;

    public void NewGame()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync("NewGame", LoadSceneMode.Additive);
    }

    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                GameObject quitObj = GameObject.FindWithTag(this.quitTag);
                quitObj.SetActive(true);
            }
        }
    }

    //Scene Quit

    public void No()
    {
        quitObj.SetActive(false);
    }

    public void Yes()
    {
        Application.Quit();
    }

    //All scene

    public void Back()
    {
        SceneManager.LoadScene(scene);
    }
}
