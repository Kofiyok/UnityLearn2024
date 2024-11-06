using UnityEngine.SceneManagement;

public class PlayerHealth : HealthContainer
{
    public override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
