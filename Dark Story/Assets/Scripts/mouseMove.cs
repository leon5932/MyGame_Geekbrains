using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
{
    //Rotation x
    public float xRot;
    
    //Rotation y
    public float yRot;

    //������
    public Camera head;

    public GameObject body;

    //���������������� ����
    public float sensivity = 5f;

    private void Update()
    {
        MouseMove();
    }
    private void MouseMove()
    {
        //������� �� �������� ���� �� ���� X � Y
        xRot += Input.GetAxis("Mouse Y") * sensivity;
        yRot += Input.GetAxis("Mouse X") * sensivity;

        xRot = Mathf.Clamp(xRot, -90, 90);

        head.transform.rotation = Quaternion.Euler(-xRot, yRot, 0f);
        body.transform.rotation = Quaternion.Euler(0f, yRot, 0f);
    }
}
