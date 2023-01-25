using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public bool occupied;
    public Transform spawnlocation;

    private void Start()
    {
        spawnlocation = this.transform;
        occupied = false;
    }
}
