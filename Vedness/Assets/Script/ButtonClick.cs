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

    //Scene Quit

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
