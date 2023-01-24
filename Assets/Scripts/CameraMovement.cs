using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public Camera mainCamera;
    public Camera polaroidCamera;
    [SerializeField] Vector2 mousePos;

    [SerializeField] Transform horizontalRotationPoint;

    [Tooltip("Up/Down")][SerializeField] private float maximumXrotation;
    [Tooltip("Up/Down")][SerializeField] private float minimumXrotation;
    [Tooltip("Left/Right")][SerializeField] private float maximumYrotation;
    [Tooltip("Left/Right")][SerializeField] private float minimumYrotation;

    [SerializeField] private Vector2 centerCoords;

    [SerializeField] private float cameraDepth;

    // Start is called before the first frame update
    void Start()
    {
        var width = Screen.width;
        var height = Screen.height;
        Vector2 centerCoords = new Vector2(width/2, height/2);
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPosition();
        DetectEnemies();
    }

    void UpdateCameraPosition()
    {
        mousePos = Mouse.current.position.ReadValue();

        // Get target Y (left/right) rotation based upon mouse position on screen
        float targetRotationY = Mathf.Lerp(minimumYrotation, maximumYrotation, mousePos.x / Screen.width);

        // Get target X (up/down) rotation based upon mouse position on screen
        float targetRotationX = Mathf.Lerp(minimumXrotation, maximumXrotation, mousePos.y / Screen.height);

        horizontalRotationPoint.localEulerAngles = new Vector3(targetRotationX, targetRotationY, 0);
    }

    //void GetWorldSpaceCoords()
    //{
    //    Vector2 mouseCoords = Mouse.current.position.ReadValue();

    //    Vector3 screenPoint = new(mouseCoords.x, mouseCoords.y, 0);
    //    Vector3 worldPoint = mainCamera.ScreenToWorldPoint(screenPoint);

    //    Debug.DrawRay(worldPoint, mainCamera.transform.forward * 10, Color.black);
    //}
    private void DetectEnemies()
    {
        Ray ray = new(polaroidCamera.transform.position, polaroidCamera.transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray.origin, sphereCastRadius, ray.direction * range, out hit, range, layerMask))
        {
            hit.transform.gameObject.SetActive(false);
            print("HIT!");
        }
    }

    [Range(0.1f, 1f)] public float sphereCastRadius;
    [Range(1f, 100f)] public float range;
    public LayerMask layerMask;
    private void OnDrawGizmos()
    {
        Ray ray = new(polaroidCamera.transform.position, polaroidCamera.transform.forward);
        RaycastHit hit;

        Gizmos.DrawWireSphere(transform.position, range);

        if (Physics.SphereCast(ray.origin, sphereCastRadius, ray.direction * range, out hit, range, layerMask))
        {
            Gizmos.color = Color.green;
            Vector3 sphereCastMidpoint = ray.origin + (ray.direction * hit.distance);
            Gizmos.DrawWireSphere(sphereCastMidpoint, sphereCastRadius);
            Gizmos.DrawSphere(hit.point, 0.1f);
            Debug.DrawLine(ray.origin, sphereCastMidpoint, Color.green);
        }
        else
        {
            Gizmos.color = Color.red;
            Vector3 sphereCastMidpoint = ray.origin + (ray.direction * (range - sphereCastRadius));
            Gizmos.DrawWireSphere(sphereCastMidpoint, sphereCastRadius);
            Debug.DrawLine(ray.origin, sphereCastMidpoint, Color.red);
        }
    }

}
