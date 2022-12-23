using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] [Tooltip("Nº horas en completar movimiento de rotación")]
    public float durationRotation = 24f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 24.0f/durationRotation, 0) * Time.deltaTime);
    }
}
