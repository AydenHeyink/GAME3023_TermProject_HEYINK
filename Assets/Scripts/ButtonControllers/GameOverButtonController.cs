using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonController : MonoBehaviour
{
    [SerializeField] string MainGameLevel = "MainGame";
    [SerializeField] string MainMenu = "MainMenu";

    public void MainMenuButton()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void MainGameButton()
    {
        SceneManager.LoadScene(MainGameLevel);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
