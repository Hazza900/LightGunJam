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
        Mouse.current.position.ReadValue();
        //GetWorldSpaceCoords();
    }

    void GetWorldSpaceCoords()
    {
        Vector2 mouseCoords = Mouse.current.position.ReadValue();

        Vector3 screenPoint = new(mouseCoords.x, mouseCoords.y, 0);
        Vector3 worldPoint = mainCamera.ScreenToWorldPoint(screenPoint);

        Debug.DrawRay(worldPoint, mainCamera.transform.forward * 10, Color.black);
    }
}
