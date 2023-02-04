//Controla las acciones a realizar cuando el usuario toque
//la pantalla del dispositivo sobre alg�n elemento de la escena

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchController : MonoBehaviour
{
    [SerializeField][Tooltip("Canvas en el que se mostrará la información de los cuerpos celestiales")]
    private CanvasSolarSystem canvasSolarSystem;

    //Para guardar el objeto sobre el que impacte el rayo
    private RaycastHit hit;
    

    private void Update()
    {    
        CheckForCelestialBodyTouch();
    }

    private void CheckForCelestialBodyTouch()
    {
        foreach(var touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {                
                var ray = Camera.main.ScreenPointToRay(touch.position);
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.transform.GetComponent<CelestialBodyInfo>() != null)
                    {
                        /*Alternativa descartada: obtener los datos de los propios objetos
                        CelestialBodyInfo celestialBody = hit.transform.GetComponent<CelestialBodyInfo>();
                        celestialBody.ShowBodyInfo();   */                       
                        
                        canvasSolarSystem.ShowCelestialBodyInfo(hit.transform.name);
                    }                                      
                }
            }
        } 
    }
    
}
