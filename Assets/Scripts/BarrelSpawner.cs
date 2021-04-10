using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    // barrel sub class to spawn
    [SerializeField]
    private GameObject barrelPrefab;

    // torque applied constantly
    [SerializeField]
    private Vector3 constantTorque;

    [SerializeField]
    private float initialSpawn = 0f;

    // spawn rate
    [SerializeField]
    private float spawnRate;

    // Note: Barrels will spawn in the location that its placed at!


    // Start is called before the first frame update
    void Start()
    {
        // Timer event called every x seconds (repeated) can optionally use "Invoke" to only spawn one barrel
        InvokeRepeating("_OnSpawnBarrel", initialSpawn, spawnRate);        
    }
    void _OnSpawnBarrel()
    {
        GameObject barrel = Instantiate(barrelPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));
        barrel.GetComponent<BarrelScript>().desiredTorque = constantTorque;


    }

}
