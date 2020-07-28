using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField]
    [Range(0,1)]
    private float delayAmount = 0.09f;

    private Vector3 referenceVelocity = Vector3.zero;
    private Vector3 finalPosition;

    private void LateUpdate()
    {
        finalPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, finalPosition, ref referenceVelocity, delayAmount);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
