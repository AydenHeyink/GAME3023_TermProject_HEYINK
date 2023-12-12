using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

#if UNITY_EDITOR
public class AddNewPlayerItem : EditorWindow
{

    string A_Name = "placeholder";
    int A_Amount = 0;

    string W_Name = "placeholder";
    int W_Damage = 0;
    int W_Stamina = 0;

    string P_Name = "Placeholder";
    int P_HealthIncrease = 0;
    int P_HealthIncreaseMax = 0;
    int P_StaminaIncrease = 0;
    int P_StaminaIncreaseMax = 0;
    int P_LuckIncrease = 0;
    int P_LuckIncreaseMax = 0;

    [MenuItem("Window/Add New Ability, Weapon, or Pickup Item")]

    public static void ShowWindow()
    {
        GetWindow<AddNewPlayerItem>("AddNewPlayerItem");
    }

    void OnGUI()
    {
        // Block to add new ability
        GUILayout.Label("Ability:", EditorStyles.boldLabel);

        A_Name = EditorGUILayout.TextField("Name", A_Name);

        A_Amount = EditorGUILayout.IntField("Amount", A_Amount);

        if (GUILayout.Button("Craft New Ability"))
        {
            PlayerStats.AddNewAbility(A_Name, A_Amount);
        }


        // Block to add new weapon
        GUILayout.Label("Weapon:", EditorStyles.boldLabel);

        W_Name = EditorGUILayout.TextField("Name", W_Name);

        W_Damage = EditorGUILayout.IntField("Damage", W_Damage);
        W_Stamina = EditorGUILayout.IntField("Stamina", W_Stamina);

        if (GUILayout.Button("Craft New Weapon"))
        {
            PlayerStats.AddNewItem(W_Name, W_Damage, W_Stamina);
        }

        
        // Block to add new pickup
        GUILayout.Label("Pickup:", EditorStyles.boldLabel);

        P_Name = EditorGUILayout.TextField("Name", P_Name);

        P_HealthIncrease = EditorGUILayout.IntField("HealthIncrease", P_HealthIncrease);
        P_HealthIncreaseMax = EditorGUILayout.IntField("HealthIncreaseMax", P_HealthIncreaseMax);

        P_StaminaIncrease = EditorGUILayout.IntField("StaminaIncrease", P_StaminaIncrease);
        P_StaminaIncreaseMax = EditorGUILayout.IntField("StaminaIncreaseMax", P_StaminaIncreaseMax);

        P_LuckIncrease = EditorGUILayout.IntField("LuckIncrease", P_LuckIncrease);
        P_LuckIncreaseMax = EditorGUILayout.IntField("LuckIncrease", P_LuckIncreaseMax);

        if (GUILayout.Button("Create new Pickup"))
        {
            PlayerStats.AddNewPickup(P_Name,
                P_HealthIncrease, P_HealthIncreaseMax,
                P_StaminaIncrease, P_StaminaIncreaseMax,
                P_LuckIncrease, P_LuckIncreaseMax);
        }
    }

}
#endif