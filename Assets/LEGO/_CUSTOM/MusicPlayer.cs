using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private static MusicPlayer instance;
    public int startingPitch = 1;
    public int timeToDecrease = 5;
    bool secret = false;
    private GameObject player;
    private GameObject crane;
    bool playerDefeated = false;
    bool craneDefeated = false;

    public AudioClip song1;
    public AudioClip song2;




    private void Start()
    {
        _audioSource.clip = song1;
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
        _audioSource.pitch = startingPitch;

    }
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        PlayMusic();

    }
    private void Update()
    {
        //crane = GameObject.Find
        if (crane == null)
        {
            crane = GameObject.Find("crane2");
        }
        else
        {
            if (crane.GetComponent<CraneDestroyed>().failed)
                craneDefeated = true;
            else
                craneDefeated = false;
        }
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
       
        if (player)
        {
            if (!player.GetComponent<Animator>().enabled)
                playerDefeated = true;
            else
                playerDefeated = false;
        }
        if (SceneManager.GetActiveScene().name == "expert")
            secret = true;
        else
            secret = false;

        if(playerDefeated && _audioSource.pitch >= 0 || craneDefeated && _audioSource.pitch >= 0)
            _audioSource.pitch -= Time.deltaTime * 2 * startingPitch / timeToDecrease;
        else if (!playerDefeated)
        {
         _audioSource.pitch =  startingPitch;
        }

        if (secret)
        {
            SongSwitch();

        }
        else
        {
            _audioSource.clip = song1;
            PlayMusic();
        }
    }
    public void SongSwitch()
    {
        _audioSource.clip = song2;
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

}
