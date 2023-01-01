//Controla el movimiento de traslación de un objeto alrededor de otro siguiendo una ruta elíptica

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
    private float translationSpeed = 10f;

    [SerializeField][Tooltip("Radio grande de la elipse")]
    private float distance = 3f;

     [SerializeField][Tooltip("Radio pequeño de la elipse")]
    private float otherDistance = 1.7f;

    [SerializeField][Tooltip("Desviación sobre el centro del objeto objetivo")]
    private float offset = 10f;

    private double sinA, cosA;
    private float3 temporalPosition;

    private double ecuationTime = 0.0f;
    

    void Update()    {
        
        EllipticalTranslation();
    }

    private void EllipticalTranslation()
    {        
        ecuationTime += Time.deltaTime * translationSpeed * 0.1f;

        sincos(ecuationTime, out sinA, out cosA);        

        temporalPosition = float3(target.transform.position.x + offset + distance * (float)sinA, target.transform.position.y, target.transform.position.z + otherDistance * (float)cosA);

        transform.position = temporalPosition;        
    }
}
