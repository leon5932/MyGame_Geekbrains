using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _mine;

    [SerializeField]
    private Transform _PointSpawner;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_mine, _PointSpawner.position, _PointSpawner.rotation);
        }
    }
}
