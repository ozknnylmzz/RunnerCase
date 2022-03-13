using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCamera : MonoBehaviour
{
    [SerializeField] Vector3 danceCameraPos;
    
    public void Rotate()
    {
        GetComponent<CameraFollow>().enabled = false;
        transform.position = danceCameraPos;
        transform.localEulerAngles = new Vector3(56.5f, -180, 0);

    }
    
}
