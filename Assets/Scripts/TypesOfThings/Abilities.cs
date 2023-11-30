using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities
{
    private string name;
    private int amt;

    public Abilities(string name, int amt)
    {
        this.name = name;
        this.amt = amt;
    }

    public string GetName()
    {
        return name;
    }

    public int GetAmt() 
    { 
        return amt;
    }

    //public static Abilities = 
}
