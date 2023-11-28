using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyType
{
    public string name;
    public int damage;
    public int health;

    public EnemyType(string name, int damage, int health)
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

static public class EnemyStats
{
    public static EnemyType Zombie = new EnemyType("Zombie", UnityEngine.Random.Range(10, 20), 70);
    public static EnemyType Skeleton = new EnemyType("Skeleton", UnityEngine.Random.Range(5, 15), 110);
    public static EnemyType Vampire = new EnemyType("Vampire", UnityEngine.Random.Range(10, 40), 90);
    public static EnemyType Werewolf = new EnemyType("Werewolf", UnityEngine.Random.Range(30, 60), 100);

    public static EnemyType currentEnemy;
}