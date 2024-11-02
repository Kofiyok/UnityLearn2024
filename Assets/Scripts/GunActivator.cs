using UnityEngine;

[RequireComponent(typeof(MissilePool))]
public class GunActivator : MonoBehaviour
{
    [SerializeField] private float _reloadTime = 1f;
    [SerializeField] private SliderBar _reloadBar;
    private float _timeUntilReload;

    private MissilePool _missilePool;

    private void Start()
    {
        _missilePool = GetComponent<MissilePool>();
        _reloadBar.SetValue(0, _reloadTime, _reloadTime - _timeUntilReload);
    }

    private void Update()
    {
        if (_timeUntilReload > 0)
        {
            _timeUntilReload -= Time.deltaTime;
            _reloadBar.SetValue(0, _reloadTime, _reloadTime - _timeUntilReload);
        }
        if (Input.GetKey(KeyCode.Mouse0) && _timeUntilReload <= 0)
        {
            _missilePool.Shoot();
            _timeUntilReload = _reloadTime;
        }
    }
}
