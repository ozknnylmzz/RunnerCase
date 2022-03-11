using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCamera : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Rotate()
    {
        GetComponent<CameraFollow>().enabled = false;
        transform.position = new Vector3(0.5f, 4, 105.5f);
        transform.localEulerAngles = new Vector3(42, -180, 0);
        
    }
}
