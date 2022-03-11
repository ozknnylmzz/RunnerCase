using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] Vector3 Distance;
    [SerializeField] Vector3 DancePos;
    float lerpTime = 1.0f;

    //private static CameraFollow instance;
    //public static CameraFollow Singleton { get => instance; set => instance = value; }
    void Start()
    {

    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position + Distance, Time.deltaTime);
    }
    
}
