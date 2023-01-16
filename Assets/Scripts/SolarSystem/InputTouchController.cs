//Controla las acciones a realizar cuando el usuario toque
//la pantalla del dispositivo sobre algún elemento de la escena

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchController : MonoBehaviour
{
    public GameObject particleSystemTest;

    private void Update()
    {
        foreach(var touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                Debug.Log("Se ha pulsado la pantalla");
                var ray = Camera.main.ScreenPointToRay(touch.position);
                if(Physics.Raycast(ray))
                {
                    Debug.Log("Se ha tocado la pantalla sobre un objeto");
                    Instantiate(particleSystemTest, transform.position, transform.rotation);                    
                }
            }
        }
    }
}
