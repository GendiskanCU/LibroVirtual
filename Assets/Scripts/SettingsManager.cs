using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfSetting { ROTATION_ON, VOLUME_ON };
public enum StatusOfSetting { NO, YES };
public class SettingsManager : MonoBehaviour
{

    //Singleton
    public static SettingsManager SharedInstance;

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

        if (!PlayerPrefs.HasKey("ROTACION_ACTIVADA")) 
        {               
            PlayerPrefs.SetInt("ROTACION_ACTIVADA", (int)StatusOfSetting.NO);
        }
        if (!PlayerPrefs.HasKey("VOLUMEN_ENCENDIDO")) 
        {               
             PlayerPrefs.SetInt("VOLUMEN_ENCENDIDO", (int)StatusOfSetting.YES);
        }
    }

    public StatusOfSetting CheckIfSettingActivated (TypeOfSetting typeOfSetting)
    {
        switch (typeOfSetting)
        {
            case TypeOfSetting.ROTATION_ON:                
                return (StatusOfSetting)PlayerPrefs.GetInt("ROTACION_ACTIVADA");                  
                break;

            case TypeOfSetting.VOLUME_ON:                
                return (StatusOfSetting)PlayerPrefs.GetInt("VOLUMEN_ENCENDIDO");                
                break;
            default:
                Debug.LogError("No se ha introducido un typeOfSetting correcto");
                return 0;
        }        
    }

    public void SetSettingStatus(TypeOfSetting typeOfSetting, StatusOfSetting newStatus)
    {
        switch (typeOfSetting)
        {
            case TypeOfSetting.ROTATION_ON:
                PlayerPrefs.SetInt("ROTACION_ACTIVADA", (int)newStatus);                
                break;
            case TypeOfSetting.VOLUME_ON:
                PlayerPrefs.SetInt("VOLUMEN_ENCENDIDO", (int)newStatus);                
                break;
            default:            
                Debug.LogError("No se ha introducido un typeOfSetting correcto");
                break;
        }        
    }
}
