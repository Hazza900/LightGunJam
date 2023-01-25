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
    public enum RegionType
    {
        NormalMovement,
        SlowMovement,
        StopMovement
    }
    public RegionType regionType;

    [SerializeField]
    List<Transform> regionSpawnLocations;
    [SerializeField]
    float spawnCooldown;
    [SerializeField]
    float currentSpawnCooldown;

    bool canSpawn;
    bool enemySpawned;
    bool cooldownActive;

    bool reducePlayerSpeed;
    bool increasePlayerSpeed;

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

        if(reducePlayerSpeed && playerCart.m_Speed > 0)
        {
            if((int)regionType == 1)
            {
                playerCart.m_Speed -= 0.005f;
                if (playerCart.m_Speed <= playerController.playerSlowSpeed)
                {
                    reducePlayerSpeed = false;
                    playerCart.m_Speed = playerController.playerSlowSpeed;
                }
            }
            else if((int)regionType == 2)
            {
                playerCart.m_Speed -= 0.0005f;
                if(playerCart.m_Speed <= 0)
                {
                    reducePlayerSpeed = false;
                    playerCart.m_Speed = 0;
                }
            }
            
        }

        if(increasePlayerSpeed && playerCart.m_Speed < playerController.defaultPlayerSpeed)
        {
            playerCart.m_Speed += 0.05f;
            if (playerCart.m_Speed >= playerController.defaultPlayerSpeed)
            {
                increasePlayerSpeed = false;
                playerCart.m_Speed = playerController.defaultPlayerSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemySpawnManager.spawnLocations.Clear();
            enemySpawnManager.spawnLocations.AddRange(regionSpawnLocations);

           
            if((int)regionType == 0)
            {
                HandleNormalMovement();
            }
            if((int)regionType == 1)
            {
                HandleSlowMovement();
            }
            if ((int)regionType == 2)
            {
                HandleStopMovement();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemySpawnManager.spawnLocations.Clear();
            increasePlayerSpeed = true;
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
        playerCart.m_Speed = playerController.defaultPlayerSpeed;
        enemySpawnManager.SpawnEnemy();
        enemySpawned = true;
        cooldownActive = true;
    }
    private void HandleSlowMovement()
    {
        reducePlayerSpeed = true;
        enemySpawnManager.SpawnEnemy();
        enemySpawned = true;
        cooldownActive = true;
    }

    private void HandleStopMovement()
    {
        playerCart.m_Speed = playerController.defaultPlayerSpeed;
        reducePlayerSpeed = true;
    }

}
