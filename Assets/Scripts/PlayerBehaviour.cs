using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 3.0f;
    [SerializeField] Rigidbody2D rb;
    Vector2 movement;
    //public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //anim.SetFloat("Horizontal", movement.x);
        //anim.SetFloat("Vertical", movement.y);
        //anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Time.timeScale = 0;
            //Destroy(collision);
            //SceneManager.LoadScene("EncounterScene", LoadSceneMode.Additive);
        }
    }
}
    
