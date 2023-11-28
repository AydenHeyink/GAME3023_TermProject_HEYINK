using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy 
{
    public string name;
    public int damage;
    public int health;

    //public static Enemy Zombie = new Enemy("Zombie", UnityEngine.Random.Range(10, 20), 70);
    //public static Enemy Skeleton = new Enemy("Skeleton", UnityEngine.Random.Range(5, 15), 110);
    //public static Enemy Vampire = new Enemy("Vampire", UnityEngine.Random.Range(10, 40), 90);
    //public static Enemy WereWolf = new Enemy("Werewolf", UnityEngine.Random.Range(30, 60), 100);

    static List<Enemy> EnemyTypes= new List<Enemy>()
    { new Enemy("Zombie", UnityEngine.Random.Range(10, 20), 70), 
      new Enemy("Skeleton", UnityEngine.Random.Range(5, 15), 110), 
      new Enemy("Vampire", UnityEngine.Random.Range(10, 40), 90), 
      new Enemy("Werewolf", UnityEngine.Random.Range(30, 60), 100)
    };

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

