using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
    // Audio players components.
    public AudioSource jumpAudio;
    public AudioSource dyingAudio;
    public AudioSource shootingAudio;
    public AudioSource benAudio;
    public AudioSource level3Audio;
    public AudioSource benLaughAudio;
    public AudioSource benYesAudio;
    public AudioSource benNoAudio;

    public void PlayJumpAudio()
    {
        //collisionAudio.clip = clip;
        jumpAudio.Play();
    }
    public void PlayDyingAudio()
    {
        //collisionAudio.clip = clip;
        dyingAudio.Play();
    }
    public void PlayShootingAudio()
    {
        //collisionAudio.clip = clip;
        shootingAudio.Play();
    }
    public void PlayLevel3Audio()
    {
        //collisionAudio.clip = clip;
       
        level3Audio.Play();
    }
    public void PlayBenLaughAudio()
    {
        //collisionAudio.clip = clip;
        benLaughAudio.Play();
    }
    public void PlayBenYesAudio()
    {
        //collisionAudio.clip = clip;
        benYesAudio.Play();
    }
    public void PlayBenNoAudio()
    {
        //collisionAudio.clip = clip;
        benNoAudio.Play();
    }
    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level3") {
            if (SceneManager.GetActiveScene().name != "Level3")
            {
                level3Audio.enabled = false;
            }
        }
    }
}
