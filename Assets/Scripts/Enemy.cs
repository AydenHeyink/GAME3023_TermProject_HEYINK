using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Image enemyHealthBar;

    [SerializeField] static float enemyHealth;
    int maxHealth;
    int minHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.fillAmount = enemyHealth / 100f;
        enemyHealth = Mathf.Clamp(enemyHealth, minHealth, maxHealth);

        if (enemyHealth < 1) 
        {
            Debug.Log("You win!");
            EncounterManager.EndEncounter();
        }
    }

    static public void EnemyTurn()
    {
        int rand = Random.Range(1, 7);
        Thread.Sleep(1000);

        switch (rand)
        {
            case 1:
                Debug.Log("Enemy uses Sword!");
                PlayerBehaviour.DamagePlayer(45);
                EncounterManager.Turn();
                break;
            case 2:
                Debug.Log("Enemy uses Dagger!");
                PlayerBehaviour.DamagePlayer(20);
                EncounterManager.Turn();
                break;
            case 3:
                Debug.Log("Enemy uses Fists!");
                PlayerBehaviour.DamagePlayer(5);
                EncounterManager.Turn();
                break;
            case 4:
                Debug.Log("Enemy uses Throwing Knives!");
                PlayerBehaviour.DamagePlayer(15);
                EncounterManager.Turn();
                break;
            case 5:
                Debug.Log("Enemy uses Steal Ability!");
                Enemy.HealEnemy(30);
                PlayerBehaviour.DamagePlayer(15);
                EncounterManager.Turn();
                break;
            case 6:
                Debug.Log("Enemy uses Health Increase!");
                Enemy.HealEnemy(50);
                EncounterManager.Turn();
                break;
            case 7:
                Debug.Log("Enemy uses Knock Out!");
                Debug.Log("Knock Out Used");
                EncounterManager.Turn();
                break;

            default: break;
        }
    }

    static public void DamageEnemy(float damage)
    {
        enemyHealth -= damage;
    }

    static public void HealEnemy(float healing)
    {
        enemyHealth += healing;
    }
}
