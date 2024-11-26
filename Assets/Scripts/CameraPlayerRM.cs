using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerRM : MonoBehaviour
{
    private Vector3 forward;

    private Vector3 right;
    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        right = Camera.main.transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
