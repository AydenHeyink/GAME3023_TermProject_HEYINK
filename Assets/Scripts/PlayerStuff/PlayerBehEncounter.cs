using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerBehEncounter : MonoBehaviour
{
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
    }

    public void LoadButtons()
    {
        for (int i = 0; i < PlayerStats.items.Count; i++)
        {
            GameObject button = Instantiate(butPref) as GameObject;

            button.transform.SetParent(GetCanvas().transform, false);
            button.gameObject.GetComponentInChildren<Text>().text = PlayerStats.items[i].GetName();
            button.gameObject.transform.position = new Vector3(250, 80 * i, 0);

            Weapons item = PlayerStats.items[i];
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClickWeapons(item));

            gameObject.SetActive(true);
        }

        for (int i = 0; i < PlayerStats.abilities.Count; i++)
        {
            GameObject button = Instantiate(butPref) as GameObject;

            button.transform.SetParent(GetCanvas().transform, false);
            button.gameObject.GetComponentInChildren<Text>().text = PlayerStats.abilities[i].GetName();
            button.gameObject.transform.position = new Vector3(750, 80 * i, 0);

            Abilities ab = PlayerStats.abilities[i];
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClickAbilites(ab));

            gameObject.SetActive(true);
        }
    }


    public void OnButtonClickWeapons(Weapons i)
    {
        string tempName = i.GetName();
        int tempDam = i.GetDamage();
        int tempStam = i.GetStamina();

        EnemyBeh.DamageEnemy(tempDam);

        PlayerStats.stamina -= tempStam;

        EncounterManager.Turn();
    }

    public void OnButtonClickAbilites(Abilities i)
    {
        string tempName = i.GetName();
        int tempAmt = i.GetAmt();

        if (i.GetName() == "Herb" && PlayerStats.Herbs > 0)
        {
            PlayerStats.health += PlayerStats.healthIncreasePickup.GetAmt();
            PlayerStats.Herbs--;
        }
        if (i.GetName() == "Coffee" && PlayerStats.Coffee > 0)
        {
            PlayerStats.stamina += PlayerStats.staminaIncreasePickup.GetAmt();
            PlayerStats.Coffee--;
        }
        if (i.GetName() == "Liquid Luck" && PlayerStats.LeafClovers > 0)
        {
            PlayerStats.luck += PlayerStats.luckIncreasePickup.GetAmt();
            PlayerStats.LeafClovers--;
        }

        EncounterManager.Turn();
    }

    // Update is called once per frame
    void Update()
    {
        herbCount.text = PlayerStats.Herbs.ToString();
        coffeeCount.text = PlayerStats.Coffee.ToString();
        leafCount.text = PlayerStats.LeafClovers.ToString();

        healthBar.fillAmount = (float)PlayerStats.health / (float)PlayerStats.maxHealth;
        staminaBar.fillAmount = (float)PlayerStats.stamina / (float)PlayerStats.maxStamina;
        luckBar.fillAmount = (float)PlayerStats.luck / (float)PlayerStats.maxStamina;
        
        PlayerStats.health = Mathf.Clamp(PlayerStats.health, PlayerStats.minHealth, PlayerStats.maxHealth);
        PlayerStats.stamina = Mathf.Clamp(PlayerStats.stamina, PlayerStats.minStamina, PlayerStats.maxStamina);
        PlayerStats.luck = Mathf.Clamp(PlayerStats.luck, PlayerStats.minLuck, PlayerStats.maxLuck);

        if (PlayerStats.health < 1)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            EncounterManager.EndEncounter();
            UnloadButtons();
        }
    }

    public void UnloadButtons()
    {
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("buttonClone"))
        {
            Destroy(button);
        }
    }
    static public void AddNew(string name, int dam, int stam)
    {
        //PlayerStats.items.Add((name, dam, stam));
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
