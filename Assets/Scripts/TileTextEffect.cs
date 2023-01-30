using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileTextEffect : MonoBehaviour
{

    private TextMeshProUGUI titulo;
    bool aumentaBrillo;
    float velocidadBrillo;
    float brilloActual;

    void Start()
    {
        brilloActual = 0f;
        titulo = GetComponent<TextMeshProUGUI>();//Capturamos el Text Mesh Pro
        titulo.fontSharedMaterial.EnableKeyword("GLOW_ON");//Activamos su propiedad de brillo "Glow"
        //Y establecemos los valores iniciales de los par�metros del brillo
        titulo.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowOffset, brilloActual);
        titulo.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowInner, 0.136f);
        titulo.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, 0.272f);
        titulo.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0.5f);

        velocidadBrillo = 0.5f;
        aumentaBrillo = true;
    }

    // Update is called once per frame
    void Update()
    {
        ModificaBrillo();
    }

    private void ModificaBrillo()
    {
        if (aumentaBrillo)
        {
            brilloActual = brilloActual + Time.deltaTime * velocidadBrillo;
            titulo.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowOffset, brilloActual);
            if (brilloActual >= 0.75f)
                aumentaBrillo = false;
        }
        else
        {
            brilloActual = brilloActual - Time.deltaTime * velocidadBrillo;
            titulo.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowOffset, brilloActual);
            if (brilloActual <= 0f)
                aumentaBrillo = true;
        }
    }
}
