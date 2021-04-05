using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
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
       // player.GetComponent<HP>().Heal += 15;
        Destroy(this.gameObject);
    }
}
