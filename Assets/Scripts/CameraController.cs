using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;

    public Vector3 newZoom;
    private Vector3 newPosition;
    private Quaternion newRotation;

    public Vector2 camLimit;

    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;   
    }

    
    void Update()
    { 
        if(GameManager.gameIsOver)
        {
            this.enabled=false;
            return;
        }
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            newPosition += (transform.right * -movementSpeed);
        }

        if(Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }

        if(Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);

        newPosition.x = Mathf.Clamp(newPosition.x,-camLimit.x,camLimit.x);
        newPosition.z = Mathf.Clamp(newPosition.z,-camLimit.y,camLimit.y);

        newZoom.y = Mathf.Clamp(newZoom.y,300,554);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime); // para girar a câmera
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}
