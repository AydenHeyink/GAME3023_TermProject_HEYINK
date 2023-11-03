using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class AddNewEnemy : EditorWindow
{
    string enemyName = "placeholder";
    int enemyDamage = 0;

    [MenuItem("Window/Add New Enemy")]

    public static void ShowWindow()
    {
        GetWindow<AddNewPlayerItem>("Add New Enemy");
    }

    void OnGUI()
    {
        // Block to add new enemy
        GUILayout.Label("Enemy:", EditorStyles.boldLabel);

        enemyName = EditorGUILayout.TextField("Name", enemyName);

        enemyDamage = EditorGUILayout.IntField("Damage", enemyDamage);

        if (GUILayout.Button("Create new Enemy"))
        {
            //PlayerBehaviour.AddNew(enemyName, enemyDamage);
        }

    }
}
