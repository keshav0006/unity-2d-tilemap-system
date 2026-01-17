using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; 

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    [Range(0.01f, 1f)] public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        if (target == null) return;

        
        Vector3 desiredPosition = target.position + offset;

       
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
