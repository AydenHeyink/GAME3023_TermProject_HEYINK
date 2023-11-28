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
            case "Encounter":
                source.clip = encounterMusic;
                source.Play();
                break;
            case "Credits":
                break;
            case "Options":
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
