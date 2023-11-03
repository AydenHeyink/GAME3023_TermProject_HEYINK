using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private string name;
    private int damage;
    private int health;

    public Enemy(string name, int damage, int health)
    {
        this.name = name;
        this.damage = damage;
        this.health = health;
    }

    public string GetName()
    {
        return name;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetHealth() 
    {
        return health;
    }
}

public class EnemyBehaviour
{
    static List<Enemy> Enemies= new List<Enemy>();

    void Start()
    {
        Enemies.Add(new Enemy("Zombie", 0, 0));
        Enemies.Add(new Enemy("Zombie", 0, 0));
        Enemies.Add(new Enemy("Zombie", 0, 0));
        Enemies.Add(new Enemy("Zombie", 0, 0));
    }

    [SerializeField] public static int whichType;
    [SerializeField] Image enemyHealthBar;

    // Enemy Attributes
    [SerializeField] static int enemyHealth;

    private int maxHealth;
    private int minHealth;

    private int minDamage;
    private int maxDamage;

    public void SetEnemy(int maxH, int minD, int maxD)
    {
        enemyHealth = maxH;
        maxHealth = maxH;
        minHealth = 0;

        minDamage = minD;
        maxDamage = maxD;
    }

    static public void DamageEnemy(int damage)
    {
        enemyHealth -= damage;
    }

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


    public int GetEnemyHealth()
    {
        return enemyHealth;
    }

    static public int MakeRandomInt(int r1, int r2)
    {
        int val = UnityEngine.Random.Range(r1, r2);
        Debug.Log("Enemy Damages player with: " + val + " damage!");

        return val;
    }
}
