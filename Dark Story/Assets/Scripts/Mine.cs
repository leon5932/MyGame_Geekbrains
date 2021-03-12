using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject mine;
    public float radius = 5f;
    public float force = 700f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject expl = Instantiate(explosionEffect, transform.position, transform.rotation);

        Destroy(mine);
        Destroy(expl);
    }

}