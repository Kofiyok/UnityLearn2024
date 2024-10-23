using UnityEngine;

public class Missile : MonoBehaviour
{
    public MissilePool Parent;
    [SerializeField] private GameObject _obj;
    [SerializeField] private float _damage = 50;

    private void FixedUpdate()
    {
        if (transform.position.y < 0)
            Parent.DestroyBullet(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
            collision.gameObject.GetComponent<HealthContainer>().DecreaseHealth(_damage);
        //ParticleSystem.Play(); for Particles of Explosion
        //_obj.SetActive(false);
        //Invoke(nameof(DeleteSelf), 0.5f);
        DeleteSelf();
    }

    private void DeleteSelf()
    {
        Parent.DestroyBullet(this);
    }
}
