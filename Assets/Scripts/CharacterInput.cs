using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    [SerializeField] float RightLeftSpeed;
    [SerializeField] float CurringSpeed;
    [SerializeField] float LimitX;
    [SerializeField] float XSpeed;

    Vector3 velocity;

    void Update()
    {
        float newX = 0;
        float TouchDelta = 0;
#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TouchDelta -= RightLeftSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            TouchDelta += RightLeftSpeed * Time.deltaTime;
        }
#endif

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            TouchDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }

        newX = transform.position.x + XSpeed * TouchDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -LimitX, LimitX);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z + CurringSpeed * Time.deltaTime);


    }
}
