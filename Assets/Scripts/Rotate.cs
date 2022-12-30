using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] [Tooltip("Nº horas en completar movimiento de rotación")]
    public float durationRotation = 24f;

    private float newAngleY;
    

    // Update is called once per frame
    void Update()
    {
        newAngleY = (24.0f / durationRotation ) * Time.deltaTime;        

        transform.Rotate(0f, newAngleY, 0f);
    }
}
