using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using SolarSystem;

public class MainScreen : MonoBehaviour
{
    TextMeshProUGUI tittleTextEffect;
    
    [SerializeField]
    [Tooltip("Campo de texto para mostrar la información de la aplicación")]
    private TextMeshProUGUI appInfoText;
    

    // Start is called before the first frame update
    void Start()
    {
        tittleTextEffect = transform.GetChild(1).GetComponent<TextMeshProUGUI>();        
        
    }

    
    public void ShowAppCredits()
    {
        ResetPanels();
        
        SolarSystemJSONDataProvider jSONDataProvider = new SolarSystemJSONDataProvider();
        appInfoText.text = jSONDataProvider.GetMainInformation();
        appInfoText.gameObject.SetActive(true);   
    }

    private void ResetPanels()
    {
        appInfoText.text = "";
        appInfoText.gameObject.SetActive(false);
    }
}
