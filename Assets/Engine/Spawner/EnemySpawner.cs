﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    //public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnpoints;         // An array of the spawn points this enemy can spawn from.
    private SpawnpointChecker spawnpoint;
    private ArrayList invisibleSpawnpoints;
    Transform spawnplace;
    //TODO add spawn settings for each enemy
    public List<GameObject> enemies; //List of enemy prefabs to be spawned

    void Start()
    {
        invisibleSpawnpoints = new ArrayList();
        

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        //InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }


    void Spawn()
    {
        //Check if spawnpoint is visible
        foreach (Transform sp in spawnpoints)
        {
            //if a spawnpoint is not visible, add it to the list
            if (!sp.GetComponent<SpawnpointChecker>().isVisible) {
                invisibleSpawnpoints.Add(sp);
            }
            if (sp.GetComponent<SpawnpointChecker>().isVisible) {
                invisibleSpawnpoints.Remove(sp);
            }
        }

        // Find a random index between zero and one less than the number of invisible spawn points.
        int spawnPointIndex = Random.Range(0, invisibleSpawnpoints.Count);
        //If there is at least 1 invisible spawnpoint, spawn an enemy
        if (invisibleSpawnpoints.Count != 0)
        {
            spawnplace = (Transform)invisibleSpawnpoints[spawnPointIndex];
            enemies.Add(Instantiate(GetRandomEnemy(enemies), spawnplace.position, spawnplace.rotation));
        }


    }
    private GameObject GetRandomEnemy(List<GameObject> enemies) {
        int randInt = Random.Range(0, enemies.Count-1);
        return enemies[randInt];
    }
}