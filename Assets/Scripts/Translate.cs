using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using static Unity.Mathematics.math;

public class Translate : MonoBehaviour
{
    [SerializeField][Tooltip("Objeto alrededor del cual gira")]
    private GameObject target;    

    [SerializeField][Tooltip("Velocidad del movimiento de traslación")]
    public float translationSpeed = 10f;

    [SerializeField][Tooltip("Radio grande y radio pequeño de la elipse")]
    public float distance = 3f;
    public float otherDistance = 1.7f;


    private double sinA, cosA;
    private float3 temporalPosition;

    private Vector3 initialPosition;

    private double ecuationTime = 0.0f;

    
    private void Start() {
        initialPosition = transform.position;
    }

    void Update()    {
        
        EllipticalTranslation();
    }

    private void EllipticalTranslation()
    {        
        ecuationTime += Time.deltaTime * translationSpeed * 0.1f;

        sincos(ecuationTime, out sinA, out cosA);        

        temporalPosition = float3(target.transform.position.x + distance * (float)sinA, transform.position.y, target.transform.position.z + otherDistance * (float)cosA);

        transform.position = temporalPosition;
        transform.position += target.transform.position;
        //transform.position += initialPosition;
    }
}
