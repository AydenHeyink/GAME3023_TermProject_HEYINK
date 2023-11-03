using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Item
{
    private string name;
    private int damage;
    private int stamina;

    public Item(string name, int damage, int stamina)
    {
        this.name = name;
        this.damage = damage;
        this.stamina = stamina;
    }

    public string GetName()
    {
        return name;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetStamina()
    {
        return stamina;
    }
}

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 3.0f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Image playerHealthBar;
    [SerializeField] Image playerStaminaBar;
    [SerializeField] Image playerLuckBar;

    [SerializeField]static float playerHealth;
    [SerializeField]static float playerStamina;
    [SerializeField]static float playerLuck;

    int maxHealth;
    int minHealth;

    Vector2 movement;

    static List<Item> items= new List<Item>();
    [SerializeField] Canvas buttonCanvas;
    [SerializeField] GameObject butPref;

    static bool UpdateButtons;

    //public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        AddNew("Sword", 40, 50);
        AddNew("Dagger", 20, 10);
        AddNew("Fists", 10, 5);
        AddNew("Throwing Knives", 5, 10);

        playerHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();

    }

    static public void AddNew(string name, int dam, int stam)
    {
        items.Add(new Item(name, dam, stam));
    }

    public Canvas GetCanvas()
    {
        return buttonCanvas;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.fillAmount = playerHealth / 100f;
        playerHealth = Mathf.Clamp(playerHealth, minHealth, maxHealth);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //anim.SetFloat("Horizontal", movement.x);
        //anim.SetFloat("Vertical", movement.y);
        //anim.SetFloat("Speed", movement.sqrMagnitude);

        if (playerHealth < 1)
        {
            // Player death
        }

        if (UpdateButtons)
        {
            for (int i = 0; i < items.Count; i++)
            {
                GameObject button = Instantiate(butPref) as GameObject;

                button.transform.SetParent(GetCanvas().transform, false);
                button.gameObject.GetComponentInChildren<Text>().text = items[i].GetName();
                button.gameObject.transform.position = new Vector3(250, 80 * i, 0);

                gameObject.SetActive(true);

                UpdateButtons = false;
            }
        }
    }

    static public void SetButtons()
    {
        UpdateButtons = true;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Time.timeScale = 0;
            Destroy(collision);
            //Enemy.SetType(0);
            SceneManager.LoadScene("EncounterScene", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Skeleton")
        {
            Time.timeScale = 0;
            Destroy(collision);
            //Enemy.SetType(1);
            SceneManager.LoadScene("EncounterScene", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Vampire")
        {
            Time.timeScale = 0;
            Destroy(collision);
            //Enemy.SetType(2);
            SceneManager.LoadScene("EncounterScene", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Werewolf")
        {
            Time.timeScale = 0;
            Destroy(collision);
            //Enemy.SetType(3);
            SceneManager.LoadScene("EncounterScene", LoadSceneMode.Additive);
        }
    }

    static public void DamagePlayer(float damage)
    {
        playerHealth -= damage;
    }

    static public void HealPlayer(float heal) 
    {
        playerHealth += heal; 
    }
}
    
