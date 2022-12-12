//Asegura que la aplicaci�n funcione a los FPS recomendados seg�n el dispositivo en el que se ejecuta

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FrameRateSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;
    }

    private void OnVuforiaStarted()
    {
        //Consulta el frame rate recomendado
        var targetFPS = VuforiaBehaviour.Instance.CameraDevice.GetRecommendedFPS();

        //Asegura que la aplicaci�n funcione a esos FPS
        if(Application.targetFrameRate != targetFPS)
        {
            Application.targetFrameRate = targetFPS;
        }
    }
}
