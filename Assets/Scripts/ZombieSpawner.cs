using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject zombiePrefab;

    [SerializeField]
    private Vector3 pos;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(zombiePrefab, pos, Quaternion.identity);
        }
    }
}
