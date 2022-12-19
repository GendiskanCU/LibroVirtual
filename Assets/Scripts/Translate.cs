using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using static Unity.Mathematics.math;

public class Translate : MonoBehaviour
{
    [SerializeField][Tooltip("Objeto alrededor del cual gira")]
    private GameObject target;

    [SerializeField][Tooltip("Nº de días en completar el movimiento de traslación")]
    private float durationTranslation = 360f;

    [SerializeField][Tooltip("Velocidad del movimiento de traslación")]
    public float translationSpeed = 20f;

    [SerializeField][Tooltip("Radio")]
    public float distance = 3f;


    private double sinA, cosA;
    private float3 temporalPosition;

    private float ecuationTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
         transform.RotateAround(target.transform.position, Vector3.up, 7200f/durationTranslation * Time.deltaTime);
    }

    private void EllipticalTranslation()
    {        
        ecuationTime += Time.deltaTime * translationSpeed * 0.1f;

        sincos(ecuationTime, out sinA, out cosA);

        temporalPosition = float3(distance * (float)sinA, transform.position.y, distance * (float)cosA);

        transform.position = temporalPosition;
        transform.position += target.transform.position;

    }
}
