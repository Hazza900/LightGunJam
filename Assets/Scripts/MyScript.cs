using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyScript : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject polaroidModel;
    [SerializeField] Vector3 mousePos;

    [SerializeField] private Vector2 centerCoords;

    [SerializeField] private float cameraDepth;

    // Start is called before the first frame update
    void Start()
    {
        var width = Screen.width;
        var height = Screen.height;
        Vector2 centerCoords = new Vector2(width/2, height/2);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
    }

    void GetWorldSpaceCoords()
    {
        
    }
}
