using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector3 cameraOffset;
    private Vector3 referenceVelocity = Vector3.zero;
    private float delayAmount = 0.05f;
    private Vector3 finalPosition;

    private void LateUpdate()
    {
        finalPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, finalPosition, ref referenceVelocity, delayAmount);
        //Vector3 smoothedPosition = Vector3.Slerp(transform.position, finalPosition, delayAmount);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
