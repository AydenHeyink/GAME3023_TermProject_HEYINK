using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                PlayMusic(gameMusic);
                break;
            case "MainMenu":
                PlayMusic(menuMusic);
                break;
            case "GameOver":
                PlayMusic(gameOverMusic);
                break;
            case "Credits":
                PlayMusic(creditsOptionsMusic);
                break;
            case "Options":
                PlayMusic(creditsOptionsMusic);
                break;
        }
    }

    void PlayMusic(AudioClip music) 
    {
        source.clip = music;
        source.Play();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
