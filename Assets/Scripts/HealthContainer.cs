using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    public float Health {get; private set; }
    [SerializeField] private float _initialHealth = 100;

    private void Start()
    {
        Health = _initialHealth;
        gameObject.tag = "Damageable";
    }

    public void DecreaseHealth(float healthPoints)
    {
        Health -= healthPoints;
        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    public void Heal(float healthPoints)
    {
        if (healthPoints < 0)
            throw new System.Exception("Ты деб**? Хилиш на отрицательное");
        Health += healthPoints;
        if (Health > _initialHealth)
            Health = _initialHealth;
    }

    public virtual void Die()
    {
        //передать наследство кошке
        Destroy(gameObject);
    }
}
