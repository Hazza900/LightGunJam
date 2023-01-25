using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy Types")]
public class EnemyTypes : ScriptableObject
{
    public GhostType ghostType;
    public GameObject ghostPrefab;
    public int ghostPointValue;

    public AudioClip ghostSFX;
    public Animation ghostAnimation;

    public float ghostVisibilityTime;

    public enum GhostType
    {
        RealGhost,
        FakeGhost
    }

}
