using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using SolarSystem;

public class MainScreen : MonoBehaviour
{
    
    [SerializeField]
    [Tooltip("Campo de texto para mostrar la información de la aplicación")]
    private TextMeshProUGUI appInfoText;

    //Vídeo de fondo de la pantalla inicial
    private GameObject mainScreenVideoPlayer;
    

    // Start is called before the first frame update
    void Start()
    {        
        mainScreenVideoPlayer = GameObject.Find("MainScreenVideoPlayer");
    }


    
    //Muestra el panel de información de la aplicación
    public void ShowAppCredits()
    {
        ResetInfo();

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

    //Da comienzo a la experiencia de AR
    public void StartApp()
    {        
        ResetInfo();
        mainScreenVideoPlayer.SetActive(false);
        this.gameObject.SetActive(false);        
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
