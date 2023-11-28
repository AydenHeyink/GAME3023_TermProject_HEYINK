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
    [SerializeField] Image playerHealthBar;
    [SerializeField] Image playerStaminaBar;
    [SerializeField] Image playerLuckBar;

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
        rb = GetComponent<Rigidbody2D>();
    }

    public Canvas GetCanvas()
    {
        return buttonCanvas;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.fillAmount = PlayerStats.health / PlayerStats.maxHealth;
        PlayerStats.health = Mathf.Clamp(PlayerStats.health, 
                                    PlayerStats.minHealth, 
                                    PlayerStats.maxHealth);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //anim.SetFloat("Horizontal", movement.x);
        //anim.SetFloat("Vertical", movement.y);
        //anim.SetFloat("Speed", movement.sqrMagnitude);
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
            Destroy(collision);
            gameObject.SetActive(false);
            Light2D.gameObject.SetActive(false);
            PlayerPrefs.SetString("Type", "Zombie");
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Skeleton")
        {
            Time.timeScale = 0;
            Destroy(collision);
            gameObject.SetActive(false);
            Light2D.gameObject.SetActive(false);
            PlayerPrefs.SetString("Type", "Skeleton");
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Vampire")
        {
            Time.timeScale = 0;
            Destroy(collision);
            gameObject.SetActive(false);
            Light2D.gameObject.SetActive(false);
            PlayerPrefs.SetString("Type", "Vampire");
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Werewolf")
        {
            Time.timeScale = 0;
            Destroy(collision);
            gameObject.SetActive(false);
            Light2D.gameObject.SetActive(false);
            PlayerPrefs.SetString("Type", "Werewolf");
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
    }

    static public void DamagePlayer(float damage)
    {
        PlayerStats.health -= damage;
    }

    static public void HealPlayer(float heal) 
    {
        PlayerStats.health += heal; 
    }
}
    
