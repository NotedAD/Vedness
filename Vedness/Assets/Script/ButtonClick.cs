using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{

    //Scene MainMenu
    static int scene;

    public void Continue()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync("Continue", LoadSceneMode.Additive);
    }

    public void NewGame()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync("NewGame", LoadSceneMode.Additive);
    }

    public void Options()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
    }

    public void InfoTheGame()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync("InfoTheGame", LoadSceneMode.Additive);
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
