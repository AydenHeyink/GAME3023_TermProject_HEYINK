using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsBottonController : MonoBehaviour
{
    public void BackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
