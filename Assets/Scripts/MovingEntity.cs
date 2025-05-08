using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    [SerializeField] Vector3[] _destenitionPoints;
    [SerializeField] float _moveSpeed;
    [SerializeField] int _startPointIdx;
    [SerializeField] bool _isReverse;


    private void Start()
    {
        transform.position = _destenitionPoints[_startPointIdx];
    }

    private void Update()
    {
        if (Vector2.Distance(_destenitionPoints[_startPointIdx], transform.position) <= 0.1f)
        {
            ChangePointIdx();
        }
        transform.position = Vector2.MoveTowards(transform.position, _destenitionPoints[_startPointIdx],_moveSpeed * Time.deltaTime);
    }
    private void ChangePointIdx() 
    {
        if (_isReverse)
        {
            if (_startPointIdx - 1 >= 0)
                _startPointIdx--;
            else 
            {
            
                _isReverse = false;
                ChangePointIdx();
            }
        }
        else 
        {
            if (_startPointIdx + 1 < _destenitionPoints.Length)
                _startPointIdx++;
            else 
            {
                _isReverse = true;
                ChangePointIdx();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for(int i = 0; i < _destenitionPoints.Length; i++) 
        {
            Gizmos.DrawSphere(_destenitionPoints[i], 0.15f);
        }
        Gizmos.DrawLineStrip(_destenitionPoints, false);
    }
}
