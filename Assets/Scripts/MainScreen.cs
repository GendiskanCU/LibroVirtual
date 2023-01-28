using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using SolarSystem;

public class MainScreen : MonoBehaviour
{
    TextMeshProUGUI tittleTextEffect;

    TextMeshProUGUI test;

    // Start is called before the first frame update
    void Start()
    {
        tittleTextEffect = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        test = transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        SolarSystemJSONDataProvider jSONDataProvider = new SolarSystemJSONDataProvider();
        test.text = jSONDataProvider.GetMainInformation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
