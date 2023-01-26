//Controla las acciones a realizar cuando el usuario toque
//la pantalla del dispositivo sobre alg�n elemento de la escena

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchController : MonoBehaviour
{    
    private AudioSource _audioSource;

    //Para guardar el objeto sobre el que impacte el rayo
    private RaycastHit hit;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
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
                        CelestialBodyInfo celestialBody = hit.transform.GetComponent<CelestialBodyInfo>();
                        celestialBody.ShowBodyInfo();                      
                        
                        _audioSource.Play(); _audioSource.Play();
                    }                                      
                }
            }
        } 
    }
    
}
