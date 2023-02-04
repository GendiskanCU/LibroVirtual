//Controla el sonido de la aplicación
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] [Tooltip("AudioSource de los efectos de sonido")]
    private AudioSource effectsSource;

    [SerializeField] [Tooltip("AudioSource de la música del juego")]
    private AudioSource musicSource;

    [SerializeField]
    [Tooltip("Clip musical de la pantalla de inicio")]
    private AudioClip mainMusic;

    [SerializeField]
    [Tooltip("Clip de sonido ambiental del sistema solar")]
    private AudioClip ambientSound;

    //Singleton
    public static SoundManager SharedInstance;

    private void Awake() {
        //Singleton permanente entre escenas distintas (si las hubiera)
        if (SharedInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SharedInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //Reproduce un efecto de sonido, deteniendo antes el que pudiera estar reproduciéndose ya
    private void PlaySound(AudioClip clipToPlay)
    {
        effectsSource.Stop();
        effectsSource.clip = clipToPlay;
        effectsSource.pitch = 1;
        effectsSource.Play();
    }

     //Reproduce un clip de música, deteniendo antes el que pudiera estar reproduciéndose ya
     private void PlayMusic(AudioClip clipToPlay)
    {
        musicSource.Stop();
        musicSource.clip = clipToPlay;
        musicSource.Play();
    }

    public void PlayMainMusic()
    {
        PlayMusic(mainMusic);
    }

    public void PlayAmbientSound()
    {
        PlayMusic(ambientSound);
    }
   
}
