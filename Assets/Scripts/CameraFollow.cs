using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] Vector3 Distance;
   
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position + Distance, Time.deltaTime);
    }
    
}
