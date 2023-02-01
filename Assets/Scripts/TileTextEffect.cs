using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileTextEffect : MonoBehaviour
{

    private TextMeshProUGUI tittle;
    bool increaseGlow;
    float glowSpeed;
    float currentGlow;

    void Start()
    {
        currentGlow = 0f;
        tittle = GetComponent<TextMeshProUGUI>();
        tittle.fontSharedMaterial.EnableKeyword("GLOW_ON");//Activa la propiedad de brillo "Glow"
        //Valores iniciales de los parámetros del brillo
        tittle.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowOffset, currentGlow);
        tittle.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowInner, 0.136f);
        tittle.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, 0.272f);
        tittle.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0.5f);

        glowSpeed = 0.5f;
        increaseGlow = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGlow();
    }

    private void ChangeGlow()
    {
        if (increaseGlow)
        {
            currentGlow = currentGlow + Time.deltaTime * glowSpeed;
            tittle.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowOffset, currentGlow);
            if (currentGlow >= 0.75f)
                increaseGlow = false;
        }
        else
        {
            currentGlow = currentGlow - Time.deltaTime * glowSpeed;
            tittle.fontSharedMaterial.SetFloat(ShaderUtilities.ID_GlowOffset, currentGlow);
            if (currentGlow <= 0f)
                increaseGlow = true;
        }
    }
}
