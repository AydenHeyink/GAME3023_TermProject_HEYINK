using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBottonController : MonoBehaviour
{
    [SerializeField] string OptionsLevel = "Options";
    [SerializeField] string MainGameLevel = "MainGame";
    [SerializeField] string CreditsLevel = "Credits";

    public void OptionsButton()
    {
        SceneManager.LoadScene(OptionsLevel);
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene(CreditsLevel);
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
