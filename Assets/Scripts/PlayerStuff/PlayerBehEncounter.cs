using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerBehEncounter : MonoBehaviour
{
    EncounterManager EM;
    public int currentDamage;

    [SerializeField] Image healthBar;
    [SerializeField] Image staminaBar;
    [SerializeField] Image luckBar;

    [SerializeField] Canvas buttonCanvas;
    [SerializeField] GameObject butPref;

    [SerializeField] TextMeshProUGUI herbCount;
    [SerializeField] TextMeshProUGUI coffeeCount;
    [SerializeField] TextMeshProUGUI leafCount;

    // Start is called before the first frame update
    void Start()
    {
        LoadButtons();
        EM = FindObjectOfType<EncounterManager>();
    }

    public void LoadButtons()
    {
        for (int i = 0; i < PlayerStats.items.Count; i++)
        {
            GameObject button = Instantiate(butPref) as GameObject;

            button.transform.SetParent(GetCanvas().transform, false);
            button.gameObject.GetComponentInChildren<Text>().text = PlayerStats.items[i].name;
            button.gameObject.transform.position = new Vector3(250, 80 * i, 0);

            Weapons item = PlayerStats.items[i];
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClickWeapons(item));

            gameObject.SetActive(true);
        }

        for (int i = 0; i < PlayerStats.abilities.Count; i++)
        {
            GameObject button = Instantiate(butPref) as GameObject;

            button.transform.SetParent(GetCanvas().transform, false);
            button.gameObject.GetComponentInChildren<Text>().text = PlayerStats.abilities[i].name;
            button.gameObject.transform.position = new Vector3(750, 80 * i, 0);

            Abilities ab = PlayerStats.abilities[i];
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClickAbilites(ab));

            gameObject.SetActive(true);
        }
    }


    public void OnButtonClickWeapons(Weapons i)
    {
        string tempName = i.name;
        int tempDam = i.damage;
        int tempStam = i.stamina;
        
        if (PlayerStats.luck > 2)
        {
            currentDamage = (tempDam * PlayerStats.luck / UnityEngine.Random.Range(1,3));
        }
        else if (PlayerStats.luck < 2) 
        {
            currentDamage = tempDam;
        }

        PlayerStats.stamina -= tempStam;
        EnemyBeh.DamageEnemy(tempDam * PlayerStats.luck / UnityEngine.Random.Range(1, 3));

        EM.SetPlayerText("Player did " + currentDamage + " Damage to enemy",
            "Player Stamina depleted " + tempStam + ", Stamina now: " + PlayerStats.stamina);

        EncounterManager.Turn(); 
    }

    public void OnButtonClickAbilites(Abilities i)
    {
        string tempName = i.name;
        int tempAmt = i.amt;

        switch(tempName)
        {
            case "Herb":
                if (PlayerStats.Herbs > 0)
                {
                    PlayerStats.health += tempAmt;
                    PlayerStats.Herbs--;
                }
                break;
            case "Coffee":
                if (PlayerStats.Coffee > 0)
                {
                    PlayerStats.stamina += tempAmt;
                    PlayerStats.Coffee--;
                }
                break;
            case "4 Leaf Clover":
                if (PlayerStats.LeafClovers > 0)
                {
                    PlayerStats.luck += tempAmt;
                    PlayerStats.LeafClovers--;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManagePlayerPickupText();
        ManageProgressBars();
        ManageAttributes();
        CheckForPlayerDeath();

        if (Input.GetKeyDown(KeyCode.T))
        {
            EncounterManager.EndEncounter();
            UnloadButtons();
        }
    }

    private static void CheckForPlayerDeath()
    {
        if (PlayerStats.health < 1)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private static void ManageAttributes()
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

    private void ManagePlayerPickupText()
    {
        herbCount.text = PlayerStats.Herbs.ToString();
        coffeeCount.text = PlayerStats.Coffee.ToString();
        leafCount.text = PlayerStats.LeafClovers.ToString();
    }

    public void UnloadButtons()
    {
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("buttonClone"))
        {
            Destroy(button);
        }
    }

    public Canvas GetCanvas()
    {
        return buttonCanvas;
    }

    static public void DamagePlayer(float damage)
    {
        PlayerStats.health -= damage;
    }

    static public void HealPlayer(float healing)
    {
        PlayerStats.health += healing;
    }
}
