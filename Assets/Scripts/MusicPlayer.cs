using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _instance;
    public List<AudioClip> LevelMusic;

    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
            _instance = this;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    private void Update()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name == "MainMenuBackground")
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.clip = LevelMusic.First();
            if(!audioSource.isPlaying)
                audioSource.Play();
        }
        else if(sceneName == "Level1" || sceneName == "Level2" || sceneName == "Level3")
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.clip = LevelMusic.Skip(1).First();
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
