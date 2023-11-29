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

    public EnemyType(string name, int minDamage, int maxDamage, int health)
    {
        this.name = name;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.health = health;
    }

    public string GetName()
    {
        return name;
    }

    public int GetRandDamage()
    {
        return UnityEngine.Random.Range(minDamage, maxDamage);
    }

    public int GetHealth()
    {
        return health;
    }
}

static public class EnemyStats
{
    public static EnemyType Zombie = new EnemyType("Zombie", 10, 20, 70);
    public static EnemyType Skeleton = new EnemyType("Skeleton", 5, 15, 110);
    public static EnemyType Vampire = new EnemyType("Vampire", 10, 40, 90);
    public static EnemyType Werewolf = new EnemyType("Werewolf", 30, 60, 100);

    public static EnemyType currentEnemy;
}