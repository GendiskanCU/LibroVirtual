using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using SolarSystem;

public class MainScreen : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Image Target que activará el sistema solar")]
    private GameObject imageTarget;

    [SerializeField]
    [Tooltip("Vídeo de fondo de la pantalla principal")]
    private GameObject mainScreenVideoPlayer;
    
    [SerializeField]
    [Tooltip("Campo de texto para mostrar la información de la aplicación")]
    private TextMeshProUGUI appInfoText;
    
    [SerializeField]
    [Tooltip("Panel de instrucciones de la aplicación")]
    private GameObject instructionsPanel;
       

    // Start is called before the first frame update
    void Start()
    {                
        SoundManager.SharedInstance.PlayMainMusic();
    }


    
    //Muestra el panel de información de la aplicación
    public void ShowAppCredits()
    {
        ResetInfo();
        HideAppInstructions();

        SolarSystemJSONDataProvider jSONDataProvider = new SolarSystemJSONDataProvider();
        appInfoText.text = jSONDataProvider.GetMainInformation();
        appInfoText.gameObject.SetActive(true);   
    }   

    //Vacía y desactiva los paneles informativos
    private void ResetInfo()
    {
        appInfoText.text = "";
        appInfoText.gameObject.SetActive(false);
    }

    public void ShowAppInstructions()
    {
        ResetInfo();
        
        instructionsPanel.SetActive(true);
    }

    public void HideAppInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    //Da comienzo a la experiencia de AR
    public void StartApp()
    {        
        ResetInfo();
        HideAppInstructions();
        
        mainScreenVideoPlayer.SetActive(false);
        this.gameObject.SetActive(false);
        imageTarget.SetActive(true);        
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        mainScreenVideoPlayer.SetActive(true);    
    }
}
