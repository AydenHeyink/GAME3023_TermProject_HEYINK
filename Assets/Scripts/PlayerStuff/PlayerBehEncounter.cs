using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerBehEncounter : MonoBehaviour
{
    [SerializeField] Image healthBar;

    [SerializeField] Canvas buttonCanvas;
    [SerializeField] GameObject butPref;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.health = PlayerStats.maxHealth;
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
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(item));

            gameObject.SetActive(true);
        }
    }


    public void OnButtonClick(Weapons i)
    {
        string tempName = i.GetName();
        int tempDam = i.GetDamage();
        int tempStam = i.GetStamina();

        Debug.Log(tempName);
        Debug.Log(tempDam);
        Debug.Log(tempStam);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = PlayerStats.health / 100f;
        PlayerStats.health = Mathf.Clamp(PlayerStats.health, PlayerStats.minHealth, PlayerStats.maxHealth);

        if (PlayerStats.health < 1)
        {
            Debug.Log("Player Dies!");
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
