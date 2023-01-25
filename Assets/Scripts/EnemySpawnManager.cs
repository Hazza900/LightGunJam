using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    EnemyTypes[] enemyTypes;
    
    public List<GameObject> spawnLocations;
    int enemyIndex;
    int locationIndex;


    public void SpawnEnemy()
    {
        enemyIndex = Random.Range(0, enemyTypes.Length);
        if (spawnLocations.Count > 0)
        {
            locationIndex = Random.Range(0, spawnLocations.Count);
            if (spawnLocations[locationIndex].GetComponent<SpawnLocation>().occupied)
            {
                locationIndex = Random.Range(0, spawnLocations.Count);
            }
        }
        else
        {
            return;
        }

        

        

        Enemy spawnedEnemy = Instantiate(enemyTypes[enemyIndex].ghostPrefab, spawnLocations[locationIndex].transform.position, spawnLocations[locationIndex].transform.rotation).GetComponent<Enemy>();
        spawnedEnemy.ghostType = (int)enemyTypes[enemyIndex].ghostType;
        spawnedEnemy.ghostAnimation = enemyTypes[enemyIndex].ghostAnimation;
        spawnedEnemy.ghostSFX = enemyTypes[enemyIndex].ghostSFX;
        spawnedEnemy.ghostPointValue = enemyTypes[enemyIndex].ghostPointValue;
        spawnedEnemy.ghostVisibilityTime = enemyTypes[enemyIndex].ghostVisibilityTime;
        spawnedEnemy.currentLocation = spawnLocations[locationIndex].GetComponent<SpawnLocation>();
        spawnLocations.RemoveAt(locationIndex);
    }
}
