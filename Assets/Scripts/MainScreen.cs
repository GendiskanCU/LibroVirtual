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

    private GameObject mainScreenVideoPlayer;
    

    // Start is called before the first frame update
    void Start()
    {        
        mainScreenVideoPlayer = GameObject.Find("MainScreenVideoPlayer");
    }


    
    public void ShowAppCredits()
    {
        ResetInfo();

        SolarSystemJSONDataProvider jSONDataProvider = new SolarSystemJSONDataProvider();
        appInfoText.text = jSONDataProvider.GetMainInformation();
        appInfoText.gameObject.SetActive(true);   
    }

    private void ResetInfo()
    {
        appInfoText.text = "";
        appInfoText.gameObject.SetActive(false);
    }

    public void StartApp()
    {        
        ResetInfo();
        mainScreenVideoPlayer.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
