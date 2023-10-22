using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    static bool B_playerTurn;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        B_playerTurn= true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void EndEncounter()
    {
        Time.timeScale=1;
        SceneManager.UnloadSceneAsync(2);
    }

    static public void Turn()
    {
        if (B_playerTurn)
        {
            B_playerTurn= false;
            Enemy.EnemyTurn();
        }
        else if (!B_playerTurn) 
        { 
            B_playerTurn= true;
        }
    }
}
