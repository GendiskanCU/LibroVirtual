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

    [SerializeField]
    [Tooltip("Clip de efecto de sonido al pulsar un botón")]
    private AudioClip buttonClickSound;

     [SerializeField]
    [Tooltip("Clip de efecto de sonido alternativo al pulsar un botón")]
    private AudioClip buttonClickSoundAlt;

    [SerializeField]
    [Tooltip("Clip de efecto de sonido al descubrir un cuerpo celestial")]
    private AudioClip celestialBodySound;

    [SerializeField]
    [Tooltip("Clip de efecto de sonido al mostrar la información de un cuerpo")]
    private AudioClip showInfoSound;

    //Singleton
    public static SoundManager SharedInstance;

    //Para controlar cuándo el sonido está silenciado
    private bool soundMuted;   

    //Para almacenar el volumen inicial de los sonidos
    private float initialMusicVolume, initialSFXVolume;
    

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

    private void Start() {
        initialMusicVolume = musicSource.volume;
        initialSFXVolume = effectsSource.volume;        
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

     private void MuteAllSounds()
    {
        musicSource.volume = 0;
        effectsSource.volume = 0;
        soundMuted = true;
    }

    private void RestoreAllSounds()
    {
        musicSource.volume = initialMusicVolume;
        effectsSource.volume = initialSFXVolume;
        soundMuted = false;
    }
   

    public void PlayMainMusic()
    {
        PlayMusic(mainMusic);
    }

    public void PlayAmbientSound()
    {
        PlayMusic(ambientSound);
    }

    public void PlayButtonClickSound()
    {
        PlaySound(buttonClickSound);
    }

    public void PlayButtonClickSoundAlt()
    {
        PlaySound(buttonClickSoundAlt);
    }

    public void PlayCelestialBodyFoundSound()
    {
        PlaySound(celestialBodySound);
    }

    public void PlayWritingInfoSound()
    {
        effectsSource.PlayOneShot(showInfoSound);
    }

    public void ChangeVolumeSounds()
    {
        if(soundMuted)
        {
            Debug.Log("Activando sonidos");
            RestoreAllSounds();
        }
        else
        {
            Debug.Log("Silenciando sonidos");
            MuteAllSounds();
        }
    }

    public void StopAllSFX()
    {
        effectsSource.Stop();
    }
   
}