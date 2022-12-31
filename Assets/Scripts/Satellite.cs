using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    [SerializeField][Range(2.5f, 3.0f)] private float maxCoordX = 2.5f;
    private float minCoordX;

    [SerializeField][Range(-2f, -2.5f)] private float minCoordZ = -2.0f;
    private float maxCoordZ;    

    [SerializeField] [Range(0.01f, 1.5f)] private float movementSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3 (maxCoordX, transform.localPosition.y, minCoordZ);
        minCoordX = -maxCoordX;
        maxCoordZ = -minCoordZ;
    }

    // Update is called once per frame
    void Update()
    {
        SimpleSatelliteMovement();
    }

    private void SimpleSatelliteMovement()
    {        
        if(transform.localPosition.x > minCoordX && transform.localPosition.z <= minCoordZ)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - (movementSpeed * Time.deltaTime),
            transform.localPosition.y, minCoordZ);
        }

        if(transform.localPosition.x <= minCoordX && transform.localPosition.z < maxCoordZ)
        {
            transform.localPosition = new Vector3(minCoordX, transform.localPosition.y,
            transform.localPosition.z + (movementSpeed * Time.deltaTime));
        }

        if(transform.localPosition.x < maxCoordX && transform.localPosition.z >= maxCoordZ)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + (movementSpeed * Time.deltaTime),
            transform.localPosition.y, maxCoordZ);
        }

        if(transform.localPosition.x >= maxCoordX && transform.localPosition.z > minCoordZ)
        {
            transform.localPosition = new Vector3(maxCoordX, transform.localPosition.y,
            transform.localPosition.z - (movementSpeed * Time.deltaTime));
        }        
    }
}
