using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

    //Scene MainMenu
    static int scene;

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
                scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("Quit", LoadSceneMode.Additive);
            }
        }
    }

    //Scene Quit

    public void No()
    {
        SceneManager.LoadScene(scene);
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
