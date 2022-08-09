using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    //—цена MainMenu

    static int scene;
    public void Continue()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
    public void NewGame()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }
    public void Options()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
    }

    public void InfoTheGame()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(5, LoadSceneMode.Additive);
    }
    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene("Quit");
            }
        }
    }

    //—цена Quit

    public void No()
    {
        SceneManager.LoadScene(scene);
    }

    public void Yes()
    {
        Application.Quit();
    }

    //ƒл€ всех сцен

    public void Back()
    {
        SceneManager.LoadSceneAsync(scene);
    }
}
