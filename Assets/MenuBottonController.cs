using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBottonController : MonoBehaviour
{
    [SerializeField] string OptionsLevel = "Options";
    [SerializeField] string MainGameLevel = "MainGame";

    public void OptionsButton()
    {
        SceneManager.LoadScene(OptionsLevel);
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
