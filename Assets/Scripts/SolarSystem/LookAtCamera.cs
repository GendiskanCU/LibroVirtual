//Fuerza que un objeto permanezca "mirando" en dirección a la cámara

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;

    private Transform thisObject;

    // Start is called before the first frame update
    void Start()
    {
        thisObject = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(2 * thisObject.position - cameraTarget.position);
    }
}
