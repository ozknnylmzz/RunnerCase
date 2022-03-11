using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraController : MonoBehaviour
{
    [SerializeField] private Vector3 dancePos;
    private Vector3 followRotation;
    private Vector3 followPos;
    private float lerpTime = 1.0f;
    void Start()
    {
        followRotation = transform.eulerAngles;
        followPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
