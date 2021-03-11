using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
{
    //Rotation x
    public float xRot;
    
    //Rotation y
    public float yRot;

    //Камера
    public Camera head;

    public GameObject body;

    //чувствительность мыши
    public float sensivity = 5f;

    private void Update()
    {
        MouseMove();
    }
    private void MouseMove()
    {
        //наклоны по движению мыши по осям X и Y
        xRot += Input.GetAxis("Mouse Y") * sensivity;
        yRot += Input.GetAxis("Mouse X") * sensivity;

        xRot = Mathf.Clamp(xRot, -90, 90);

        head.transform.rotation = Quaternion.Euler(-xRot, yRot, 0f);
        body.transform.rotation = Quaternion.Euler(0f, yRot, 0f);
    }
}
