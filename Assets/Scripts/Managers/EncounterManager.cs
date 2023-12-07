using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerText;
    [SerializeField] TextMeshProUGUI PlayerText2;

    [SerializeField] TextMeshProUGUI EnemyText;
    [SerializeField] TextMeshProUGUI EnemyText2;

    static bool B_playerTurn;

    // Start is called before the first frame update
    void Start()
    {
        PlayerText.text = "";
        B_playerTurn= true;
        PlayerStats.isEncounter = true;
    }

    static public void EndEncounter()
    {
        Time.timeScale=1;
        PlayerStats.isEncounter = false;
        SceneManager.UnloadSceneAsync("Encounter");
    }

    static public void Turn()
    {
        if (B_playerTurn)
        {
            B_playerTurn= false;
            EnemyBeh.EnemyTurn();
        }
        else if (!B_playerTurn) 
        { 
            B_playerTurn= true;
        }
    }

    public void SetPlayerText(string text, string text2)
    {
        PlayerText.text = text;
        PlayerText2.text = text2;
    }

    public void SetEnemyText(string text, string text2)
    {
        EnemyText.text = text;
        EnemyText2.text = text2;
    }
}
