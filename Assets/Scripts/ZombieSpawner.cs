using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject normalZombiePrefab;

    [SerializeField]
    private GameObject slowZombiePrefab;

    [SerializeField]
    private Vector3 pos;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(normalZombiePrefab, pos, Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(slowZombiePrefab, pos, Quaternion.identity);
        }
    }
}
