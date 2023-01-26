using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using Cinemachine;
using System.ComponentModel.Design.Serialization;

public class SpawnRegion : MonoBehaviour
{
    private EnemySpawnManager enemySpawnManager;
    [SerializeField]
    CinemachineDollyCart playerCart;
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    List<Transform> regionSpawnLocations;
    [SerializeField]
    List<GameObject> specialSpawns;
    [SerializeField]
    float spawnCooldown;
    [SerializeField]
    float currentSpawnCooldown;

    bool canSpawn;
    bool enemySpawned;
    bool cooldownActive;

    float delta;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnManager = FindObjectOfType<EnemySpawnManager>();
        playerController = FindObjectOfType<PlayerController>();
        playerCart = FindObjectOfType<CinemachineDollyCart>();
    }

    private void Update()
    {
        delta = Time.deltaTime;
        if(enemySpawned && cooldownActive)
        {
            if(currentSpawnCooldown < spawnCooldown && enemySpawnManager.spawnLocations.Count > 0)
            {
                currentSpawnCooldown += delta;
            }
            else if(currentSpawnCooldown >= spawnCooldown)
            {
                canSpawn = true;
                enemySpawned = false;
                cooldownActive = false;
                currentSpawnCooldown = 0;
            }
        }

        if(canSpawn && !enemySpawned && !cooldownActive && enemySpawnManager.spawnLocations.Count > 0)
        {
            HandleEnemySpawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemySpawnManager.spawnLocations.Clear();
            enemySpawnManager.spawnLocations.AddRange(regionSpawnLocations);

            enemySpawnManager.specialEnemyTypes.Clear();
            if(specialSpawns.Count > 0) enemySpawnManager.specialEnemyTypes.AddRange(specialSpawns);

            HandleNormalMovement();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemySpawnManager.spawnLocations.Clear();
            canSpawn = false;
            enemySpawned = false;
            cooldownActive = false;

        }
    }

    private void HandleEnemySpawn()
    {
        enemySpawnManager.SpawnEnemy();
        cooldownActive = true;
        enemySpawned = true;
        canSpawn = false;
    }

    private void HandleNormalMovement()
    {
        enemySpawnManager.SpawnEnemy();
        enemySpawned = true;
        cooldownActive = true;
    }


}
