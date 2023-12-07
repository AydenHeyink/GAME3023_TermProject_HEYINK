using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons 
{
    public string name;
    public int damage;
    public int stamina;

    public Weapons(string name, int damage, int stamina)
    {
        this.name = name;
        this.damage = damage;
        this.stamina = stamina;
    }
}

public class Pickup
{
    public string name;

    public int healthIncrease;
    public int maxHealthIncrease;

    public int staminaIncrease;
    public int maxStaminaIncrease;

    public float luckIncrease;
    public float maxLuckIncrease;

    public Pickup(string name, int healthIncrease, int maxHealthIncrease, 
                               int staminaIncrease, int maxStaminaIncrease,
                               float luckIncrease, float maxLuckIncrease)
    {
        this.name = name;
        
        this.healthIncrease = healthIncrease;
        this.maxHealthIncrease = maxHealthIncrease;
        
        this.staminaIncrease = staminaIncrease;
        this.maxStaminaIncrease = maxStaminaIncrease;

        this.luckIncrease = luckIncrease;
        this.maxLuckIncrease = maxLuckIncrease;
    }
}
