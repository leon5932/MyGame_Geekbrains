using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsKey : MonoBehaviour
{
    public float activeRange = 3f;
    public GameObject player;

    private void Update()
    {
        Vector3 distanceToPlayer = player.transform.position - this.transform.position;

        if (distanceToPlayer.magnitude <= activeRange && Input.GetKeyDown(KeyCode.E))
        {
            TakeIt();
        }
    }

    void TakeIt()
    {
        player.GetComponent<Movement>().DoorsKey = true;
        Destroy(this.gameObject);
    }
}
