using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // The object the camera will follow

    public GameObject target; // ASSIGN IN EDITOR

    // The offset distance between the camera and the target 

    public Vector3 posOffset; // ASSIGN IN EDITOR 
    
    // Start is called before the first frame update
    void Start()
    {
        // Calcuate the distance between the target and the camera 
        // posOffset = transform.position - target.transform.position;
        transform.position = target.transform.position + posOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            transform.position = target.transform.position + posOffset;
        }

        // Move the camera to follow the target using the offset.
        
    }
}
