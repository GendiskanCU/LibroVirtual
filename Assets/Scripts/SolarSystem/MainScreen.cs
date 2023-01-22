using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainScreen : MonoBehaviour
{
    TextMeshProUGUI tittleTextEffect;

    // Start is called before the first frame update
    void Start()
    {
        tittleTextEffect = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
