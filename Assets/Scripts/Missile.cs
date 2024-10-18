using UnityEngine;

public class Missile : MonoBehaviour
{
    public MissilePool Parent;

    private void FixedUpdate()
    {
        if (transform.position.y < 0)
            Parent.DestroyBullet(this);
    }
}
