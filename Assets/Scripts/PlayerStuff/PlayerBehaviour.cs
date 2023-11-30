using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 3.0f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Image healthBar;
    [SerializeField] Image staminaBar;
    [SerializeField] Image luckBar;

    [SerializeField] GameObject Light2D; 

    [SerializeField]static float playerStamina;
    [SerializeField]static float playerLuck;

    Vector2 movement;

    [SerializeField] Canvas buttonCanvas;
    [SerializeField] GameObject butPref;

    static private bool isSceneEnc;

    //public Animator anim;
    void Start()
    {

        PlayerStats.Herbs = 1;
        PlayerStats.Coffee = 1;
        PlayerStats.LeafClovers = 1;

        PlayerStats.health = PlayerStats.maxHealth;
        PlayerStats.stamina = PlayerStats.maxStamina;
        PlayerStats.luck= PlayerStats.maxLuck;

        rb = GetComponent<Rigidbody2D>();   
    }

    public Canvas GetCanvas()
    {
        return buttonCanvas;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerStats.isEncounter)
        {
            PlayerStats.stamina += 0.005f;
        }

        healthBar.fillAmount = (float)PlayerStats.health / (float)PlayerStats.maxHealth;
        staminaBar.fillAmount = (float)PlayerStats.stamina / (float)PlayerStats.maxStamina;
        luckBar.fillAmount = (float)PlayerStats.luck / (float)PlayerStats.maxStamina;

        PlayerStats.health = Mathf.Clamp(PlayerStats.health, PlayerStats.minHealth, PlayerStats.maxHealth);
        PlayerStats.stamina = Mathf.Clamp(PlayerStats.stamina, PlayerStats.minStamina, PlayerStats.maxStamina);
        PlayerStats.luck = Mathf.Clamp(PlayerStats.luck, PlayerStats.minLuck, PlayerStats.maxLuck); 
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //anim.SetFloat("Horizontal", movement.x);
        //anim.SetFloat("Vertical", movement.y);
        //anim.SetFloat("Speed", movement.sqrMagnitude);

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

    static public bool GetEncBool()
    {
        return isSceneEnc;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    static public void SetEncBool(bool b)
    {
        isSceneEnc = b;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Time.timeScale = 0;
            Destroy(collision.gameObject);
            Light2D.gameObject.SetActive(false);
            PlayerPrefs.SetString("Type", "Zombie");
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Skeleton")
        {
            Time.timeScale = 0;
            Destroy(collision);
            Light2D.gameObject.SetActive(false);
            PlayerPrefs.SetString("Type", "Skeleton");
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Vampire")
        {
            Time.timeScale = 0;
            Destroy(collision.gameObject);
            Light2D.gameObject.SetActive(false);
            PlayerPrefs.SetString("Type", "Vampire");
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Werewolf")
        {
            Time.timeScale = 0;
            Destroy(collision.gameObject);
            Light2D.gameObject.SetActive(false);
            PlayerPrefs.SetString("Type", "Werewolf");
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "herb")
        {
            Destroy(collision.gameObject);
            PlayerStats.Herbs++;
        }
        else if (collision.gameObject.tag == "coffee")
        {
            Destroy(collision.gameObject);
            PlayerStats.Coffee++;
        }
        else if (collision.gameObject.tag == "liquidluck")
        {
            Destroy(collision.gameObject);
            PlayerStats.LeafClovers++;
        }
        else if (collision.gameObject.tag == "potion")
        {
            Destroy(collision.gameObject);
            PlayerStats.maxHealth += 5;
        }
        else if (collision.gameObject.tag == "coffeebean")
        {
            Destroy(collision.gameObject);
            PlayerStats.maxStamina += 5;

        }
        else if (collision.gameObject.tag == "LuckIncrease")
        {
            Destroy(collision.gameObject);
            PlayerStats.maxLuck += 1;

        }
    }
}
    
