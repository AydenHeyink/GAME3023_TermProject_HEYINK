using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    static bool B_playerTurn;
    int enemyType;

    // Start is called before the first frame update
    void Start()
    {
        B_playerTurn= true;
    }

    static public void EndEncounter()
    {
        Time.timeScale=1;
        SceneManager.UnloadSceneAsync("Encounter");
    }

    static public void Turn()
    {
        if (B_playerTurn)
        {
            B_playerTurn= false;
            //Enemy.EnemyTurn();
        }
        else if (!B_playerTurn) 
        { 
            B_playerTurn= true;
        }
    }
}
