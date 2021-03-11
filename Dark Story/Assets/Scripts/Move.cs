using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed = 6f;

    public float jumpForce = 12f;

    private Vector3 move;

    private void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");



    }

    private void FixedUpdate()
    {
        var moving = move * (speed * Time.fixedDeltaTime);
        transform.Translate(moving);
    }
}

