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

    //Para controlar si se ha cargado ya la configuración inicial de sonido
    private bool initialConfigurationCharged = false;

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

        if(SettingsManager.SharedInstance.CheckIfSettingActivated(TypeOfSetting.VOLUME_ON) == StatusOfSetting.NO)
            MuteAllSounds();
        if(SettingsManager.SharedInstance.CheckIfSettingActivated(TypeOfSetting.VOLUME_ON) == StatusOfSetting.YES)
            RestoreAllSounds();

    }

    //Reproduce un efecto de sonido, deteniendo antes el que pudiera estar reproduciéndose ya
    private void PlaySound(AudioClip clipToPlay)
    {
        effectsSource.Stop();
        //effectsSource.loop = false;        
        effectsSource.pitch = 1;
        effectsSource.PlayOneShot(clipToPlay);
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
        effectsSource.loop = true;
        effectsSource.clip = showInfoSound;
        effectsSource.Play();
    }

    public void ChangeVolumeSounds()
    {
        if(initialConfigurationCharged)
        {
            if(soundMuted)
            {
                Debug.Log("Activando sonidos");
                RestoreAllSounds();
                SettingsManager.SharedInstance.SetSettingStatus(TypeOfSetting.VOLUME_ON, StatusOfSetting.YES);
            }
            else
            {
                Debug.Log("Silenciando sonidos");
                MuteAllSounds();
                SettingsManager.SharedInstance.SetSettingStatus(TypeOfSetting.VOLUME_ON, StatusOfSetting.NO);
            }
        }
        else
            initialConfigurationCharged = true;//La primera vez que se ejecute el método se limita a modificar esto
    }

    public void StopAllSFX()
    {
        effectsSource.Stop();
        effectsSource.loop = false;
    }
   
}
