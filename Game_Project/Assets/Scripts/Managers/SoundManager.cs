using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneSound 
{
    Title=0,
    Game=1
}


public class SoundManager :SingleTon<SoundManager>
{
    [SerializeField] AudioSource scenerySource;
    [SerializeField] AudioSource effectSource;
    SceneSound sceneSound;
   public void Sound(AudioClip audioClip)
   {
        effectSource.PlayOneShot(audioClip);
   }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene , LoadSceneMode mode) 
    {
        sceneSound = (SceneSound)scene.buildIndex;
        scenerySource.clip = ResourcesManager.Instance.Load<AudioClip>(sceneSound.ToString());
        scenerySource.loop = true; 
        scenerySource.Play();
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }

}
