using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBeh : MonoBehaviour
{
    public string type;
    public GameObject enemyLocation;

    public List<Sprite> enemyPngs = new List<Sprite>();

    void Start()
    {
        transform.localScale = new Vector3(3,3,3); 
        
        type = PlayerPrefs.GetString("Type");
        switch (type)
        {
            case "Zombie":
                EnemyStats.currentEnemy = EnemyStats.Zombie;
                GetComponent<SpriteRenderer>().sprite = enemyPngs[0];
                break;
            case "Werewolf":
                EnemyStats.currentEnemy = EnemyStats.Werewolf;
                GetComponent<SpriteRenderer>().sprite = enemyPngs[1];
                break;
            case "Skeleton":
                EnemyStats.currentEnemy = EnemyStats.Skeleton;
                GetComponent<SpriteRenderer>().sprite = enemyPngs[2];
                break;
            case "Vampire":
                EnemyStats.currentEnemy = EnemyStats.Zombie;
                GetComponent<SpriteRenderer>().sprite = enemyPngs[3];
                break;
        }
        GetComponent<SpriteRenderer>().flipX= true;

        maxHealth = EnemyStats.currentEnemy.GetHealth();
    }

    [SerializeField] Image enemyHealthBar;

    // Enemy Attributes
    [SerializeField] static int enemyHealth;

    private int maxHealth;
    private int minHealth = 0;

    static public void DamageEnemy(int damage)
    {
        EnemyStats.currentEnemy.health -= damage;
    }

    void Update()
    {
        enemyHealthBar.fillAmount = (float)EnemyStats.currentEnemy.GetHealth() / (float)GetEnemyMaxHealth();

        transform.position = enemyLocation.transform.position;

        EnemyStats.currentEnemy.health = Mathf.Clamp(
                                         EnemyStats.currentEnemy.health, 
                                         minHealth, 
                                         GetEnemyMaxHealth());

        if (EnemyStats.currentEnemy.health < 1)
        {
            Debug.Log("You win!");
            EncounterManager.EndEncounter();
        }
    }


    public int GetEnemyMaxHealth()
    {
        return maxHealth;
    }

    static public void EnemyTurn()
    {
        int dam = EnemyStats.currentEnemy.GetRandDamage();
        PlayerStats.health -= dam;

        EncounterManager.Turn();
    }

    static public int MakeRandomInt(int r1, int r2)
    {
        int val = UnityEngine.Random.Range(r1, r2);
        Debug.Log("Enemy Damages player with: " + val + " damage!");

        return val;
    }
}
