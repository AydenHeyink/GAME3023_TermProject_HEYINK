using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PlayerStats 
{
    public static float health;
    public static int maxHealth = 100;
    public static int minHealth = 0;

    public static float stamina;
    public static int maxStamina = 100;
    public static int minStamina = 0;

    public static float luck;
    public static int maxLuck = 1;
    public static int minLuck = 0;

    public static bool isEncounter;

    static public PlayerBehaviour p;

    public static Weapons sword = new Weapons("Sword", 40, 50);
    public static Weapons dagger = new Weapons("Dagger", 20, 10);
    public static Weapons fists = new Weapons("Fists", 10, 5);
    public static Weapons throwingKnives = new Weapons("Throwing Knives", 5, 10);

    public static List<Weapons> items = new List<Weapons>()
    {
        sword,
        dagger,
        fists,
        throwingKnives
    };

    public static Pickup maxHealthIncreasePickup = new Pickup("MagicPotion", 0, 10, 0, 0, 0, 0);
    public static Pickup maxStaminaIncreasePickup = new Pickup("Coffee-Flower", 0, 0, 0, 10, 0, 0);
    public static Pickup maxLuckIncreasePickup = new Pickup("Liquid Luck", 0, 0, 0, 0, 0, 1);

    public static List<Pickup> pickups = new List<Pickup>()
    {
        maxHealthIncreasePickup,
        maxStaminaIncreasePickup,
        maxLuckIncreasePickup,
    };

    public static Abilities healthIncreasePickup = new Abilities("Herb", 50);
    public static Abilities staminaIncreasePickup = new Abilities("Coffee", 30);
    public static Abilities luckIncreasePickup = new Abilities("4 Leaf Clover", 1);

    public static List<Abilities> abilities = new List<Abilities>()
    {
        healthIncreasePickup,
        staminaIncreasePickup,
        luckIncreasePickup,
    };

    static public void AddNewItem(string name, int dam, int stam)
    {
        items.Add(new Weapons(name, dam, stam));
    }
}
