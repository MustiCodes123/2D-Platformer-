using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // Reference to your player GameObject
    public Transform mainCamera; // Reference to the camera's Transform
    public float upwardThreshold = 12f; // Height above which the camera moves up
    public float downwardThreshold = 0f; // Height below which the camera moves down
    public float cameraUpwardDistance = 12f; // Distance the camera moves up
    public float cameraDownwardDistance = 12f; // Distance the camera moves down

    public float initialCameraY; // Initial Y position of the camera

    void Start()
    {
        if (mainCamera != null)
        {
            initialCameraY = mainCamera.position.y; // Store the initial Y position of the camera
        }
    }

    void Update()
    {
        if (player != null && mainCamera != null)
        {
            float playerHeight = player.position.y;

            if (playerHeight > upwardThreshold && upwardThreshold % 12 == 0)
            {
                MoveCameraUp();
                upwardThreshold += 12;
                downwardThreshold += 12;
            }
            else if (playerHeight < downwardThreshold && downwardThreshold % 12 == 0)
            {
                MoveCameraDown();
                upwardThreshold -= 12;
                downwardThreshold -= 12;
            }
        }
    }

    void MoveCameraUp()
    {
        Vector3 newPosition = mainCamera.position;
        newPosition.y = initialCameraY + cameraUpwardDistance;

        // Move the camera instantly to the new position
        mainCamera.position = newPosition;
        initialCameraY = mainCamera.position.y;
    }

    void MoveCameraDown()
    {
        Vector3 newPosition = mainCamera.position;
        newPosition.y = initialCameraY - cameraDownwardDistance;

        // Move the camera instantly to the new position
        mainCamera.position = newPosition;
        initialCameraY = mainCamera.position.y;
    }
}
