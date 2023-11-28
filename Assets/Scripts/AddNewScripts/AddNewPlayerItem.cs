using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class AddNewPlayerItem : EditorWindow
{
    string A_Name = "placeholder";
    int A_Damage = 0;
    int A_Stamina = 0;

    string W_Name = "placeholder";
    int W_Damage = 0;
    int W_Stamina = 0;

    [MenuItem("Window/Add New Ability or Weapon")]

    public static void ShowWindow()
    {
        GetWindow<AddNewPlayerItem>("AddNewPlayerItem");
    }

    void OnGUI()
    {
        // Block to add new ability
        GUILayout.Label("Ability:", EditorStyles.boldLabel);

        A_Name = EditorGUILayout.TextField("Name", A_Name);

        A_Damage = EditorGUILayout.IntField("Damage", A_Damage);
        A_Stamina = EditorGUILayout.IntField("Stamina", A_Stamina);

        if (GUILayout.Button("Craft New Ability"))
        {
            //PlayerBehaviour.AddNewItem(A_Name, A_Damage, A_Stamina);
        }


        // Block to add new weapon
        GUILayout.Label("Weapon:", EditorStyles.boldLabel);

        W_Name = EditorGUILayout.TextField("Name", W_Name);

        W_Damage = EditorGUILayout.IntField("Damage", W_Damage);
        W_Stamina = EditorGUILayout.IntField("Stamina", W_Stamina);

        if (GUILayout.Button("Craft New Weapon"))
        {
            //PlayerBehaviour.AddNewItem(W_Name, W_Damage, W_Stamina);
        }
    }

}
