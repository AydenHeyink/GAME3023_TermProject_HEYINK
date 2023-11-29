using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    static bool B_playerTurn;

    // Start is called before the first frame update
    void Start()
    {
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
}
