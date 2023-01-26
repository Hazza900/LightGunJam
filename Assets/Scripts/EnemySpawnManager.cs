using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> normalEnemyTypes;

    public List<GameObject> specialEnemyTypes;
    public List<Transform> spawnLocations;

    int enemyIndex;
    int locationIndex;

    int typeOfSpawn;


    public void SpawnEnemy()
    {
        if (specialEnemyTypes.Count > 0) typeOfSpawn = Random.Range(0, 2);
        else typeOfSpawn = 0;

        if(typeOfSpawn == 0)
        {
            enemyIndex = Random.Range(0, normalEnemyTypes.Count);
            if (spawnLocations.Count > 0)
            {
                locationIndex = Random.Range(0, spawnLocations.Count);
                Instantiate(normalEnemyTypes[enemyIndex], spawnLocations[locationIndex].position, spawnLocations[locationIndex].rotation);
                spawnLocations.RemoveAt(locationIndex);
            }
            else if(specialEnemyTypes.Count > 0)
            {
                enemyIndex = Random.Range(0, specialEnemyTypes.Count);

                if (!specialEnemyTypes[enemyIndex].activeSelf)
                {
                    specialEnemyTypes[enemyIndex].SetActive(true);
                    specialEnemyTypes.RemoveAt(enemyIndex);
                }
            }
        }

        else if(typeOfSpawn == 1)
        {
            enemyIndex = Random.Range(0, specialEnemyTypes.Count);

            if (!specialEnemyTypes[enemyIndex].activeSelf)
            {
                specialEnemyTypes[enemyIndex].SetActive(true);
                specialEnemyTypes.RemoveAt(enemyIndex);
            }
            else
            {
                enemyIndex = Random.Range(0, normalEnemyTypes.Count);
                if (spawnLocations.Count > 0)
                {
                    locationIndex = Random.Range(0, spawnLocations.Count);
                    Instantiate(normalEnemyTypes[enemyIndex], spawnLocations[locationIndex].position, spawnLocations[locationIndex].rotation);
                    spawnLocations.RemoveAt(locationIndex);
                }
                else
                {
                    return;
                }
            }

        }


       
    }
}
