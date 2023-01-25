using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class SpawnRegion : MonoBehaviour
{
    private EnemySpawnManager enemySpawnManager;
    public enum RegionType
    {
        NormalMovement,
        SlowMovement,
        StopMovement
    }
    public RegionType regionType;

    [SerializeField]
    List<GameObject> regionSpawnLocations;
    [SerializeField]
    float spawnCooldown;
    [SerializeField]
    float currentSpawnCooldown;

    [SerializeField]
    bool canSpawn;
    [SerializeField]
    bool enemySpawned;
    [SerializeField]
    bool cooldownActive;

    float delta;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnManager = FindObjectOfType<EnemySpawnManager>();
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

            enemySpawnManager.SpawnEnemy();
            enemySpawned = true;
            cooldownActive = true;
        }
    }

    private void HandleEnemySpawn()
    {
        enemySpawnManager.SpawnEnemy();
        cooldownActive = true;
        enemySpawned = true;
        canSpawn = false;
    }

}
