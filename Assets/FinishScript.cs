using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] Material[] FinisLine;
    

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="Player")
        {

        }
    }
}
