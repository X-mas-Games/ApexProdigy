using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public enum FollowMode
    {
        LockOn,
        SmoothFollow,
        VelocityMatch
    }

    [Header("Target")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10);
    [SerializeField] private FollowMode followMode = FollowMode.SmoothFollow;

    [Header("Smooth Follow")]
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Velocity Match")]
    [SerializeField] private Rigidbody targetRigidbody;

    private void LateUpdate()
    {
        switch (followMode)
        {
            case FollowMode.LockOn:
                LockOnFollow();
                break;

            case FollowMode.SmoothFollow:
                SmoothFollow();
                break;

            case FollowMode.VelocityMatch:
                VelocityFollow();
                break;
        }
    }

    private void LockOnFollow()
    {
        transform.position = target.position + offset;
    }

    private void SmoothFollow()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }

    private void VelocityFollow()
    {
        if (targetRigidbody != null)
        {
            transform.position += targetRigidbody.linearVelocity * Time.deltaTime;
        }
    }
}