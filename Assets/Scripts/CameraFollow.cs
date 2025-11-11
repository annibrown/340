using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // Drag your player here
    public float smoothSpeed = 0.1f; // How quickly the camera catches up
    public Vector3 offset;     // Usually (0, 0, -10)

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = player.position + offset;
    }
}

