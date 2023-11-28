using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsBottonController : MonoBehaviour
{
    [SerializeField] string BackButton = "MainMenu";
    public void BackButtonPressed()
    {
        SceneManager.LoadScene(BackButton);
    }
}
