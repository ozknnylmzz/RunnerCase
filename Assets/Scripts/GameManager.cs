using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] Objects;
    [SerializeField] GameObject Lego;
   

    [SerializeField] float offsetZ = 10f;
  

    float[] PosX;

    float yPos = 1f;
    float zPos = 20;


    int a = 0;
    int t = 0;

    void Start()
    {
        Time.timeScale = 0;
        PosX = new float[3];
        PosX[0] = -1.5f;
        PosX[1] = .5f;
        PosX[2] = 2f;


        collectObjCreated();
    }


   
    void collectObjCreated()
    {
        for (int i = 0; i < 4; i++)
        {
            Objects.Shuffle();
            a = 0;

            foreach (GameObject item in Objects)
            {
                for (int b = 0; b < 5; b++)
                {
                    Instantiate(item, new Vector3(PosX[a], yPos, zPos + t), Quaternion.identity);
                    t++;
                }
                a++;
                t = 0;
            }
            
            zPos += offsetZ;
        }
    }




}