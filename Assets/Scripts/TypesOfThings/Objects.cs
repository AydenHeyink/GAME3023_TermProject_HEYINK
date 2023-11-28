using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons 
{
    private string name;
    private int damage;
    private int stamina;

    public Weapons(string name, int damage, int stamina)
    {
        this.name = name;
        this.damage = damage;
        this.stamina = stamina;
    }

    public string GetName()
    {
        return name;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetStamina()
    {
        return stamina;
    }
}

public class Pickup
{
    private string name;
    
    private int healthIncrease;
    private int maxHealthIncrease;
    
    private int staminaIncrease;
    private int maxStaminaIncrease;

    private float luckIncrease;
    private float maxLuckIncrease;

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
