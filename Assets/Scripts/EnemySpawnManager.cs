using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> normalEnemyTypes;
    [SerializeField]
    List<GameObject> specialEnemyTypes;

    public List<Transform> spawnLocations;
    int enemyIndex;
    int locationIndex;

    int typeOfSpawn;


    public void SpawnEnemy()
    {
        typeOfSpawn = Random.Range(0, 2);

        if(typeOfSpawn == 0)
        {
            enemyIndex = Random.Range(0, normalEnemyTypes.Count);
            if (spawnLocations.Count > 0)
            {
                locationIndex = Random.Range(0, spawnLocations.Count);
                Instantiate(normalEnemyTypes[enemyIndex], spawnLocations[locationIndex].position, spawnLocations[locationIndex].rotation);
                spawnLocations.RemoveAt(enemyIndex);
            }
            else
            {
                return;
            }
        }

        else if(typeOfSpawn == 1)
        {
            enemyIndex = Random.Range(0, specialEnemyTypes.Count);

            if (!specialEnemyTypes[enemyIndex].activeSelf)
            {
                specialEnemyTypes[enemyIndex].SetActive(true);
            }
            else
            {
                enemyIndex = Random.Range(0, normalEnemyTypes.Count);
                if (spawnLocations.Count > 0)
                {
                    locationIndex = Random.Range(0, spawnLocations.Count);
                    Instantiate(normalEnemyTypes[enemyIndex], spawnLocations[locationIndex].position, spawnLocations[locationIndex].rotation);
                    spawnLocations.RemoveAt(enemyIndex);
                }
                else
                {
                    return;
                }
            }

        }


       
    }
}
