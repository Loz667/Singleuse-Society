using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiNavMesh : MonoBehaviour
{
    public float _wanderRadius;
    public float _wanderTimer;
    //public float _turnSpeed;

    NavMeshAgent _navMeshAgent;

    float _timer;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        //_navMeshAgent.updateRotation = false;
        _timer = _wanderTimer;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, _wanderRadius, -1);
            _navMeshAgent.SetDestination(newPos);
            Vector3 direction = (newPos - transform.position).normalized;
            Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            if (_navMeshAgent.velocity.sqrMagnitude > Mathf.Epsilon)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, 360);
            }
            _timer = 0;
        }
    }

    private void LateUpdate()
    {
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDir = Random.insideUnitSphere * dist;
        randomDir += origin;

        NavMeshHit _navHit;
        NavMesh.SamplePosition(randomDir, out _navHit, dist, layermask);

        return _navHit.position;
    }
}
