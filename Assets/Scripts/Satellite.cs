using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    [SerializeField] private float maxCoordX = 2.5f, minCoordX = -2.5f,   
    maxCoordZ = 2.0f, minCoordZ = -2.0f;

    [SerializeField] private float movementSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3 (maxCoordX, transform.localPosition.y, minCoordZ);
    }

    // Update is called once per frame
    void Update()
    {
        SimpleSatelliteMovement();
    }

    private void SimpleSatelliteMovement()
    {
        if(transform.localPosition.x >= maxCoordX && transform.localPosition.z < maxCoordZ)
        {
            transform.localPosition = new Vector3(maxCoordX, transform.localPosition.y,
            transform.localPosition.z + (movementSpeed * Time.deltaTime));
        }

        if(transform.localPosition.x > minCoordX && transform.localPosition.z >= maxCoordZ)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - (movementSpeed * Time.deltaTime),
            transform.localPosition.y, maxCoordZ);
        }

        if(transform.localPosition.x <= minCoordX && transform.localPosition.z > minCoordZ)
        {
            transform.localPosition = new Vector3(minCoordX, transform.localPosition.y,
            transform.localPosition.z - (movementSpeed * Time.deltaTime));
        }

        if(transform.localPosition.x < maxCoordX && transform.localPosition.z <= minCoordZ)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + (movementSpeed * Time.deltaTime),
            transform.localPosition.y, minCoordZ);
        }
    }
}
