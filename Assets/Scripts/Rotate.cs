using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] [Tooltip("Nº horas en rotar sobre sí mismo")]
    public float durationRotation;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 24.0f/durationRotation, 0) * Time.deltaTime);
    }
}
