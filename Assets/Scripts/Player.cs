using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // HEALTH   
    [SerializeField] int m_health;

    [SerializeField] int m_maxHealth;
    [SerializeField] int m_minHealth;

    // STAMINA
    [SerializeField] float f_stamina;

    [SerializeField] float f_maxStamina;
    [SerializeField] float f_mixStamina;

    // LUCK
    [SerializeField] float m_luck;

    [SerializeField] float m_minLuck;
    [SerializeField] float m_maxLuck;

    // ALL WEAPONS/ABILITES
    [SerializeField] string m_currentAbility;
    [SerializeField] string m_currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
