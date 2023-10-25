using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Enemy Type 
    string[] enemyNames = new string[] { "Zombie", "Skeleton", "Vampire", "Werewolf" };

    [SerializeField] public Sprite[] sprites = new Sprite[] { };
    [SerializeField] public Sprite enemySprite;

    [SerializeField] public static int whichType;

    // Enemy Attributes
    [SerializeField] static int enemyHealth;
    [SerializeField] static string enemyType;


    private int maxHealth;
    private int minHealth;

    // Enemy UI 
    [SerializeField] Image enemyHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        switch (whichType)
        {
            case 1:
                SetEnemy(sprites[0], enemyNames[0], 70, 70);
                break;
            case 2:
                SetEnemy(sprites[1], enemyNames[1], 110, 110);
                break;
            case 3:
                SetEnemy(sprites[2], enemyNames[2], 90, 90);
                break;
            case 4:
                SetEnemy(sprites[3], enemyNames[3], 100, 100);
                break;
            default:
                break;
        }
    }

    static public int MakeRandomInt(int r1, int r2)
    {
        int val = UnityEngine.Random.Range(r1, r2);
        Debug.Log("Enemy Damages player with: " + val + " damage!");

        return val;
    }

    public void SetEnemy(Sprite type, string name, int maxH, int health)
    {
        enemySprite= type;
        GetComponent<SpriteRenderer>().sprite = enemySprite;

        enemyType= name;
        
        enemyHealth = health;
        maxHealth = maxH;
        minHealth = 0;
    }
    public int GetEnemyHealth()
    {
        return enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.fillAmount = enemyHealth / GetEnemyHealth();
        enemyHealth = Mathf.Clamp(enemyHealth, minHealth, maxHealth);

        if (enemyHealth < 1) 
        {
            Debug.Log("You win!");
            EncounterManager.EndEncounter();
        }
    }

    static public void EnemyTurn()
    {
        switch (whichType)
        {
            case 1:
                PlayerBehaviour.DamagePlayer(MakeRandomInt(10, 20));
                //EncounterManager.Turn();
                break;
            case 2:
                PlayerBehaviour.DamagePlayer(MakeRandomInt(5, 15));
                //EncounterManager.Turn();
                break;
            case 3:
                PlayerBehaviour.DamagePlayer(MakeRandomInt(10, 40));
                //EncounterManager.Turn();
                break;

            case 4:
                PlayerBehaviour.DamagePlayer(MakeRandomInt(30, 60));
                //EncounterManager.Turn();
                break;
        }
    }

    static public void DamageEnemy(int damage)
    {
        enemyHealth -= damage;
    }
}
