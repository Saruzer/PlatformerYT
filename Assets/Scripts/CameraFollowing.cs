using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private Vector2 _offset;
    [SerializeField] private float _smoothTime;
    private Vector3 velocity;

    void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(_target.position.x + _offset.x, _target.position.y + _offset.y, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, _smoothTime);
    }
}
