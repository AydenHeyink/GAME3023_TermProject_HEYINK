using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource source;

    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameMusic;
    [SerializeField] AudioClip encounterMusic;
    [SerializeField] AudioClip creditsOptionsMusic;
    [SerializeField] AudioClip gameOverMusic;
    string scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;

        switch (scene) 
        {
            case "MainGame":
            
                source.clip= gameMusic; 
                source.Play();
                break;
            case "MainMenu":
                source.clip = menuMusic;
                source.Play();
                break;
            case "GameOver":
                source.clip = gameOverMusic;
                source.Play();
                break;
            case "Credits":
                source.clip = creditsOptionsMusic;
                source.Play();
                break;
            case "Options":
                source.clip = creditsOptionsMusic;
                source.Play();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
