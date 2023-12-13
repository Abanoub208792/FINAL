using UnityEngine;

public class MouseZoom : MonoBehaviour
{
    private Camera Cam;
    public float TargetZoom = 3;
    private float ScrollData;
    public float ZoomSpeed = 3;

    void Start()
    {
        Cam = GetComponent<Camera>();
        TargetZoom = Cam.orthographicSize;
    }

    void Update()
    {
        ScrollData = Input.GetAxis("Mouse ScrollWheel");

        // Adjust the TargetZoom based on the scrolling input
        TargetZoom -= ScrollData * ZoomSpeed;

        // Clamp the camera and set limits to avoid zooming in or out too much
        TargetZoom = Mathf.Clamp(TargetZoom, 6, 8);

        // Smoothly interpolate between the current size and the target size
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
    }
}
