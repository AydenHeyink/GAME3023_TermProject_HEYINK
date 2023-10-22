using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    //public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
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
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy_Zombie")
        {
            //Time.timeScale = 0;
            //Destroy(collision);
            //SceneManager.LoadScene("EncounterScene", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.tag == "Enemy_Skeletion")
        {

        }
        else if (collision.gameObject.tag == "Enemy_Vampire")
        {

        }
        else if (collision.gameObject.tag == "Enemy_Werewolf")
        {

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
    
