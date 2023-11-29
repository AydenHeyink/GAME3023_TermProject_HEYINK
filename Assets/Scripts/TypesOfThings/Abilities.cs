using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities
{
    private string name;
    private int heal;

    public Abilities(string name, int heal)
    {
        this.name = name;
        this.heal = heal;
    }

    public string GetName()
    {
        return name;
    }

    public int GetHeal() 
    { 
        return heal;
    }

    //public static Abilities = 
}
