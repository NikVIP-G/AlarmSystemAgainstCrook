using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class Crook : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _way;

    private Transform[] _wayPoints;
    private int _numberCurrentWayPoint;
    private Vector3 _currentWayPoint;

    private void Start()
    {
        _wayPoints = new Transform[_way.childCount];

        for (int i = 0;  i < _way.childCount; i++)
        {
            _wayPoints[i] = _way.GetChild(i);
        }

        _currentWayPoint = _wayPoints[_numberCurrentWayPoint].position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentWayPoint, _speed * Time.deltaTime);

        if (transform.position == _currentWayPoint) 
            NextPoint();
    }

    private void NextPoint()
    {
        _numberCurrentWayPoint = ++_numberCurrentWayPoint % _wayPoints.Length;
        _currentWayPoint = _wayPoints[_numberCurrentWayPoint].position;
    }
}
