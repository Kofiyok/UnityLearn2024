using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public MissilePool Parent;
    [SerializeField] private float _damage = 50;

    private void OnEnable()
    {
        StartCoroutine(WaitSecondsAndDie(5));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
            collision.gameObject.GetComponent<HealthContainer>().DecreaseHealth(_damage);
        DeleteSelf();
    }

    private IEnumerator WaitSecondsAndDie(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        DeleteSelf();
    }

    private void DeleteSelf()
    {
        Parent.DestroyBullet(this);
    }
}
