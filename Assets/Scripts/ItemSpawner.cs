using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    float _spawnTime = 1f;
    float _plasticSpawn = 3f;
    float _wasteSpawn = 1.5f;
    [SerializeField] GameObject _plasticPrefab;
    [SerializeField] GameObject _wastePrefab;
    [SerializeField] Transform _spawner;

    WasteManager wasteManager;

    // Start is called before the first frame update
    void Start()
    {
        wasteManager = GameObject.Find("Game Manager").GetComponent<WasteManager>();
        InvokeRepeating("SpawnPlastic", _spawnTime + .25f, _plasticSpawn);
        InvokeRepeating("SpawnWaste", _spawnTime, _wasteSpawn);
    }

    void SpawnPlastic()
    {
        Instantiate(_plasticPrefab, _spawner.position + Vector3.zero * Random.Range(-1, 1), Quaternion.identity);
        wasteManager.currentWaste++;
    }

    void SpawnWaste()
    {
        Instantiate(_wastePrefab, _spawner.position + Vector3.zero * Random.Range(-2, 2), Quaternion.identity);
        wasteManager.currentWaste++;
    }
}
