using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public Transform[] backgrounds; // Array of background layers to be parallaxed
    public float[] parallaxScales; // The proportion of the camera's movement to move the backgrounds by
    public float smoothing = 1f; // How smooth the parallax effect will be

    private Transform cam; // Reference to the main camera's transform
    private Vector3 previousCamPos; // The position of the camera in the previous frame

    void Start()
    {
        cam = Camera.main.transform; // Set reference to the main camera
        previousCamPos = cam.position; // Set the initial previous frame position
    }

    void Update()
    {
        // For each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // The parallax is the opposite of the camera movement because the previous frame is multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // Calculate a target x position which is the current position + parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Create a target position which is the background's current position with its target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Smoothly move the background towards the target position
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}
