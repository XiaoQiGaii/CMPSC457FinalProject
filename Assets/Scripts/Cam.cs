using UnityEngine;

public class Cam : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        // Get the Camera component
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle between Perspective and Orthographic
            cam.orthographic = !cam.orthographic;

            // Optional: Set orthographic size or perspective field of view
            if (cam.orthographic)
            {
                cam.orthographicSize = 5; // Adjust the orthographic size as needed
            }
            else
            {
                cam.fieldOfView = 60; // Adjust the perspective FOV as needed
            }
        }
    }
}
