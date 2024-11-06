using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _reloadTime = 1f;
    [SerializeField] private float _turretTurnSpeed = 90f;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private MissilePool _misslePool;
    private float _timeUntilReload;

    private void FixedUpdate()
    {
        if (_timeUntilReload > 0)
        {
            _timeUntilReload -= Time.fixedDeltaTime;
        }

        float angleTowards = Vector3.SignedAngle(transform.forward, _enemyMovement.Target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, angleTowards, 0), _turretTurnSpeed * Time.fixedDeltaTime);
        if (_timeUntilReload <= 0 && Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo))
        {
            if (hitInfo.transform == _enemyMovement.Target)
            {
                _timeUntilReload = _reloadTime;
                _misslePool.Shoot();
            }
        }
    }

}
