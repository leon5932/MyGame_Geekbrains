using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Rotation : MonoBehaviour
{
    private Vector3 _player;
    //[SerializeField] private float _distance;
    [SerializeField] private Transform turret;
    [SerializeField] private Transform player;
    private float timeBtwShots;
    [SerializeField] public float startBtwShots;
    public GameObject projectTile;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        _player = player.position;
        var _distance = Vector3.Distance(transform.position, _player);
        Debug.Log(_distance);
        if(_distance >= 7)
        {
            transform.Rotate(1.0f, 1.0f, 0);
        }
        else
        {
            var position = transform.position - player.position;
            var rotation = Quaternion.LookRotation(position);
            turret.rotation = rotation;

            if(timeBtwShots <= 0)
            {
                Instantiate(projectTile, transform.position, Quaternion.identity);
                timeBtwShots = startBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

    }
}
