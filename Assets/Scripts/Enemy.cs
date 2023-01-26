using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public int ghostType;
    public int ghostPointValue;
    private AudioSource source;
    public AudioClip[] ghostSFX;
    [SerializeField]
    private Material ghostMat;
    public float fearPerSecond;
    public float ghostFearReduction;

    float dissolve = 10;

    bool killGhost;
    bool possessedFake;

    private void Start()
    {
        source = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        if(ghostType == 0) ghostMat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        if (ghostMat == null) possessedFake = true;
    }

    private void Update()
    {
        if(killGhost)
        {
            dissolve -= Time.deltaTime * 10;
            ghostMat.SetFloat("_cut_off_height", dissolve);

            if (dissolve <= -5) Destroy(this.gameObject);
        }
    }

    public void PlaySFX()
    {
        int index = Random.Range(0, ghostSFX.Length);
        source.clip = ghostSFX[index];

        source.Play();
    }

    public void KillGhost()
    {
        if(!possessedFake) killGhost = true;
        else Destroy(this.gameObject);
    }

}
