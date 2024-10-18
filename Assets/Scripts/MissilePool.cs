using UnityEngine;
using UnityEngine.Pool;

public class MissilePool : MonoBehaviour
{
    private ObjectPool<Missile> _pool;
    [SerializeField] private GameObject _missilePrefab;
    [SerializeField] private float _launchSpeed = 35f;

    private void Start()
    {
        _pool = new ObjectPool<Missile>(CreateNewBullet, OnGet, OnRelease);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            Shoot();
    }

    private Missile CreateNewBullet()
    {
        GameObject bullet = Instantiate(_missilePrefab);
        bullet.transform.parent = null;
        return bullet.GetComponent<Missile>();
    }

    private void OnRelease(Missile bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnGet(Missile bullet)
    {
        bullet.Parent = this;
        bullet.gameObject.SetActive(true);
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }

    public void Shoot()
    {
        var bullet = _pool.Get();
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * _launchSpeed;
    }

    public void DestroyBullet(Missile bullet)
    {
        _pool.Release(bullet);
    }
}
