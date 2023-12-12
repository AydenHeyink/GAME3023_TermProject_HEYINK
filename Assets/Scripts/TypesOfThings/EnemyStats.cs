using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyType
{
    public string name;
    public int minDamage;
    public int maxDamage;
    public int health;
    public int minHealth;
    public int maxHealth;

    public EnemyType(string name, int minDamage, int maxDamage, int health)
    {
        this.name = name;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.health = health;
        this.minHealth = 0;
        this.maxHealth = health;
    }

    public int GetRandDamage()
    {
        return UnityEngine.Random.Range(minDamage, maxDamage);
    }
}

static public class EnemyStats
{
    public static EnemyType Zombie = new EnemyType("Zombie", 10, 20, 70);
    public static EnemyType Skeleton = new EnemyType("Skeleton", 5, 15, 110);
    public static EnemyType Vampire = new EnemyType("Vampire", 10, 40, 90);
    public static EnemyType Werewolf = new EnemyType("Werewolf", 30, 60, 100);

    public static List<EnemyType> EnemyTypeList = new List<EnemyType>()
    { Zombie, Skeleton, Vampire, Werewolf};

    public static EnemyType currentEnemy;
}