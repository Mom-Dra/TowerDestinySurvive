using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] rains;

    [SerializeField]
    private GameObject normalZombiePrefab;

    [SerializeField]
    private GameObject slowZombiePrefab;

    [SerializeField]
    private Vector3 pos;

    [SerializeField]
    [Range(1f, 5f)]
    private float minSpawnCool;

    [SerializeField]
    [Range(6f, 10f)]
    private float maxSpawnCool;

    [SerializeField]
    private int maxZombieCountPerRain;

    private void Start()
    {
        foreach (Transform rain in rains)
            StartCoroutine(SpawnZombie(rain));
    }

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

    private IEnumerator SpawnZombie(Transform rain)
    {
        int spawnCount = 0;

        while (true)
        {
            WaitForSeconds wait = new WaitForSeconds(Random.Range(minSpawnCool, maxSpawnCool));
            yield return wait;

            int val = Random.Range(0, 2);

            GameObject spawnPrefab = default;

            switch(val)
            {
                case 0:
                    // normal Zombie
                    spawnPrefab = normalZombiePrefab;
                    break;

                case 1:
                    // slow Zombie
                    spawnPrefab = slowZombiePrefab;
                    break;
            }

            Instantiate(spawnPrefab, pos, Quaternion.identity, rain);

            ++spawnCount;

            if (spawnCount == maxZombieCountPerRain) break;
        }
    }
}
