using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform Target;

    private NavMeshAgent _agent;
    private Rigidbody _enemyBody;

    private void Start()
    {
        _agent.updatePosition = false;
        _enemyBody = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        print(Target);
    }

    private void FixedUpdate()
    {
        _agent.SetDestination(Target.position);
        Vector3 movement = _enemyBody.transform.forward * Vector3.Dot(_enemyBody.transform.forward, _agent.desiredVelocity);
        _enemyBody.velocity = movement;
        _agent.nextPosition = transform.position;
    }
}
