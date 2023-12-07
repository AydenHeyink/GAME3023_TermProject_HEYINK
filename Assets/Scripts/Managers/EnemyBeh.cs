using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBeh : MonoBehaviour
{
    static EncounterManager EM;

    public string type;
    public GameObject enemyLocation;
    public SpriteRenderer EnemySpriteRenderer;

    public List<Sprite> enemyPngs = new List<Sprite>();

    void Start()
    {
        EM = FindObjectOfType<EncounterManager>();

        EnemySpriteRenderer= GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(3,3,3); 
        type = PlayerPrefs.GetString("Type");
        
        switch (type)
        {
            case "Zombie":
                EnemyStats.currentEnemy = EnemyStats.Zombie;
                EnemySpriteRenderer.sprite = enemyPngs[0];
                break;
            case "Werewolf":
                EnemyStats.currentEnemy = EnemyStats.Werewolf;
                EnemySpriteRenderer.sprite = enemyPngs[1];
                break;
            case "Skeleton":
                EnemyStats.currentEnemy = EnemyStats.Skeleton;
                EnemySpriteRenderer.sprite = enemyPngs[2];
                break;
            case "Vampire":
                EnemyStats.currentEnemy = EnemyStats.Zombie;
                EnemySpriteRenderer.sprite = enemyPngs[3];
                break;
        }
        EnemySpriteRenderer.flipX= true;
    }

    [SerializeField] Image enemyHealthBar;

    // Enemy Attributes
    [SerializeField] static int enemyHealth;

    static public void DamageEnemy(int damage)
    {
        EnemyStats.currentEnemy.health -= damage;

        if (EnemyStats.currentEnemy.health < 1)
        {
            Debug.Log("You win!");
            EncounterManager.EndEncounter();
        }
    }

    void Update()
    {
        ManageEnemyHealth();
        transform.position = enemyLocation.transform.position;
    }

    private void ManageEnemyHealth()
    {
        enemyHealthBar.fillAmount = 
            (float)EnemyStats.currentEnemy.health / 
            (float)EnemyStats.currentEnemy.maxHealth;
        
        EnemyStats.currentEnemy.health = Mathf.Clamp(
                                         EnemyStats.currentEnemy.health,
                                         EnemyStats.currentEnemy.minDamage,
                                         EnemyStats.currentEnemy.maxHealth);
    }

    static public void EnemyTurn()
    {
        int dam = EnemyStats.currentEnemy.GetRandDamage();
        PlayerStats.health -= dam;

        EM.SetEnemyText("Enemy does " + dam + " Damage to Player", 
            "Player Health now: " + PlayerStats.health);

        EncounterManager.Turn();
    }
}
