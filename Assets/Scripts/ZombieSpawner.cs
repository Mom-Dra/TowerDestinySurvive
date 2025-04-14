using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] rains;

    [SerializeField]
    private Vector3[] poses;

    [SerializeField]
    private GameObject normalZombiePrefab;

    [SerializeField]
    private GameObject slowZombiePrefab;

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
        for (int i = 0; i < rains.Length; ++i)
            StartCoroutine(SpawnZombie(rains[i], poses[i], i + LayerMask.NameToLayer("Zombie1")));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(normalZombiePrefab, poses[0], Quaternion.identity, rains[0]);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(slowZombiePrefab, poses[0], Quaternion.identity, rains[0]);
        }
    }

    private IEnumerator SpawnZombie(Transform rain, Vector3 pos, int zombieLayer)
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
                    spawnPrefab = normalZombiePrefab;
                    break;

                case 1:
                    spawnPrefab = slowZombiePrefab;
                    break;
            }

            GameObject zombie = Instantiate(spawnPrefab, pos, Quaternion.identity, rain);

            Transform[] transforms = zombie.transform.GetComponentsInChildren<Transform>();
            foreach (Transform transform in transforms) transform.gameObject.layer = zombieLayer;

            ++spawnCount;

            if (spawnCount == maxZombieCountPerRain) break;
        }
    }
}
