using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static Transform player;
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
