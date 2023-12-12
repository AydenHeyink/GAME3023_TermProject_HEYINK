using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 3.0f;

    [SerializeField] static float playerStamina;
    [SerializeField] static float playerLuck;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] Image healthBar;
    [SerializeField] Image staminaBar;
    [SerializeField] Image luckBar;

    [SerializeField] GameObject Light2D;
    [SerializeField] GameObject butPref;

    public bool onChest;

    Vector2 movement;

    //public Animator anim;
    void Start()
    {
        SetPlayerStats();

        rb = GetComponent<Rigidbody2D>();
    }

    private static void SetPlayerStats()
    {
        PlayerStats.Herbs = 1;
        PlayerStats.Coffee = 1;
        PlayerStats.LeafClovers = 1;

        PlayerStats.health = PlayerStats.maxHealth;
        PlayerStats.stamina = PlayerStats.maxStamina;
        PlayerStats.luck = PlayerStats.maxLuck;
    }

    void Update()
    {
        ManageProgressBars();
        ManagePlayerAttributes();

        IncreaseStaminaInWorld();
        SetMovementToAxisPlanes();
        CheckForScene();
    }

    private void CheckForScene()
    {
        if (PlayerStats.isEncounter == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        if (PlayerStats.isEncounter == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private void SetMovementToAxisPlanes()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private static void ManagePlayerAttributes()
    {
        PlayerStats.health = Mathf.Clamp(PlayerStats.health, PlayerStats.minHealth, PlayerStats.maxHealth);
        PlayerStats.stamina = Mathf.Clamp(PlayerStats.stamina, PlayerStats.minStamina, PlayerStats.maxStamina);
        PlayerStats.luck = Mathf.Clamp(PlayerStats.luck, PlayerStats.minLuck, PlayerStats.maxLuck);
    }

    private void ManageProgressBars()
    {
        healthBar.fillAmount = (float)PlayerStats.health / (float)PlayerStats.maxHealth;
        staminaBar.fillAmount = (float)PlayerStats.stamina / (float)PlayerStats.maxStamina;
        luckBar.fillAmount = (float)PlayerStats.luck / (float)PlayerStats.maxLuck;
    }

    private static void IncreaseStaminaInWorld()
    {
        if (!PlayerStats.isEncounter)
        {
            PlayerStats.stamina += 0.005f;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + 
                        movement * 
                        MoveSpeed * 
                        Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        string objTag = collision.gameObject.tag;

        switch(objTag)
        {
            case "Zombie":
                Time.timeScale = 0;
                Destroy(collision.gameObject);
                Light2D.gameObject.SetActive(false);
                PlayerPrefs.SetString("Type", "Zombie");
                SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
                break;
            case "Skeleton":
                Time.timeScale = 0;
                Destroy(collision);
                Light2D.gameObject.SetActive(false);
                PlayerPrefs.SetString("Type", "Skeleton");
                SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
                break;
            case "Vampire":
                Time.timeScale = 0;
                Destroy(collision.gameObject);
                Light2D.gameObject.SetActive(false);
                PlayerPrefs.SetString("Type", "Vampire");
                SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
                break;
            case "Werewolf":
                Time.timeScale = 0;
                Destroy(collision.gameObject);
                Light2D.gameObject.SetActive(false);
                PlayerPrefs.SetString("Type", "Werewolf");
                SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
                break;
            case "herb":
                Destroy(collision.gameObject);
                PlayerStats.Herbs++;
                break;
            case "coffee":
                Destroy(collision.gameObject);
                PlayerStats.Coffee++;
                break;
            case "liquidluck":
                Destroy(collision.gameObject);
                PlayerStats.LeafClovers++;
                break;
            case "potion":
                Destroy(collision.gameObject);
                PlayerStats.maxHealth += 5;
                break;
            case "coffeebean":
                Destroy(collision.gameObject);
                PlayerStats.maxStamina += 5;
                break;
            case "LuckIncrease":
                Destroy(collision.gameObject);
                PlayerStats.maxLuck += 1;
                break;
            case "Chest":
                collision.gameObject.GetComponent<ChestManager>().OpenChest();
                break;
            case "gameend":
                SceneManager.LoadScene("Credits");
                break;
            default:
                break;
        }
    }
}
    
