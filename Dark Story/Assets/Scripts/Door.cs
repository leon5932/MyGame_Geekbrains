using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float openDoor;
    [SerializeField]
    private float closeDoor;
    [SerializeField]
    private float speed;

    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, openDoor, transform.rotation.z), speed * Time.deltaTime);
    }

    void CloseDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, closeDoor, transform.rotation.z), speed * Time.deltaTime);
    }
}
