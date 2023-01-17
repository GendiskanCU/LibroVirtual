//Controla las acciones a realizar cuando el usuario toque
//la pantalla del dispositivo sobre alg�n elemento de la escena

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchController : MonoBehaviour
{
    //public GameObject particleSystemTest;
    private AudioSource _audioSource;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        /*for(int i = 0; i < Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if(Physics.Raycast(ray))
                {
                    _audioSource.Play();
                }
            }
        }*/

        
        foreach(var touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {                
                var ray = Camera.main.ScreenPointToRay(touch.position);
                if(Physics.Raycast(ray))
                {
                    _audioSource.Play();_audioSource.Play();
                    //Instantiate(particleSystemTest, transform.position, transform.rotation);                    
                }
            }
        } 
    }
}
