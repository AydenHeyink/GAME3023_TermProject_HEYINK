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

public class Ability
{
    private string name;
    private int amount;

    public Ability(string name, int amount)
    {
        this.name = name;
        this.amount = amount;    }

    public string GetName()
    {
        return name;
    }

    public int GetAmount()
    {
        return amount;
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

    static Item sword = new Item("Sword", 40, 50);
    static Item dagger = new Item("Dagger", 20, 10);
    static Item fists = new Item("Fists", 10, 5);
    static Item throwingKnives = new Item("Throwing Knives", 5, 10);

    //static Ability steal = new Ability("Steal", 30);
    //static Ability knockout = new Ability("Knockout", 3);
    //static Ability steal = new Ability("Steal", 30);
    //static Ability steal = new Ability("Steal", 30);

    static List<Item> items= new List<Item>() 
        {sword,dagger,fists, throwingKnives };

    static List<Ability> abilities = new List<Ability>() 
        { };
    [SerializeField] Canvas buttonCanvas;
    [SerializeField] GameObject butPref;

    static private bool isSceneEnc;

    //public Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
       
    }

    void Start()
    {

        playerHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    static public void AddNewItem(string name, int dam, int stam)
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            EncounterManager.EndEncounter();
            UnloadButtons();
        }
 
    }

    public void LoadButtons()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject button = Instantiate(butPref) as GameObject;

            button.transform.SetParent(GetCanvas().transform, false);
            button.gameObject.GetComponentInChildren<Text>().text = items[i].GetName();
            button.gameObject.transform.position = new Vector3(250, 80 * i, 0);

            Item item = items[i];
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));

            gameObject.SetActive(true);
        }
    }

    public void OnButtonClick(Item i)
    {
        string tempName = i.GetName();
        int tempDam = i.GetDamage();
        int tempStam = i.GetStamina();
        
        Debug.Log(i.GetName());
    }

    public void UnloadButtons()
    {
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("buttonClone"))
        { 
            Destroy(button);
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
            Destroy(collision);
            //Enemy.SetType(0);
            LoadButtons();
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Skeleton")
        {
            Time.timeScale = 0;
            Destroy(collision);
            //Enemy.SetType(1);
            LoadButtons();
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Vampire")
        {
            Time.timeScale = 0;
            Destroy(collision);
            //Enemy.SetType(2);
            LoadButtons();
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Werewolf")
        {
            Time.timeScale = 0;
            Destroy(collision);
            //Enemy.SetType(3);

            LoadButtons();
            SceneManager.LoadScene("Encounter", LoadSceneMode.Additive);
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
    
