using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    InputManager inputManager;

    [SerializeField]
    float reloadInput;
    [SerializeField]
    float shootInput;

    bool shot;
    bool canReload;

    [SerializeField]
    int ammo = 5;


    [SerializeField]
    Image player;
    [SerializeField]
    TextMeshProUGUI ammoCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = inputManager.GetMouseInput();
        //Debug.Log(inputManager.GetMouseInput());
        shootInput = inputManager.GetLClickInput();
        reloadInput = inputManager.GetRClickInput();

        if (shootInput > 0 && shot == false && ammo > 0)
        {
            shot = true;
            ammo -= 1;
            player.color = Color.red;
        }
        else if(shootInput <= 0)
        {
            shot = false;
            player.color = Color.green;
        }

        if (reloadInput > 0 && canReload)
        {
            ammo = 5;
        }

        if(ammo <= 0)
        {
            canReload = true;
        }

        ammoCount.text = ammo.ToString();
    }
}
