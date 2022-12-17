using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] float enemyHealthPoints = 100f;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    private void KillEnemy()
    {
        if (enemyHealthPoints < 0)
        {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            Destroy(gameObject);
        }  
    }

    private void ProcessHit()
    {
        enemyHealthPoints -= 10f;
        Debug.Log(enemyHealthPoints);
        scoreBoard.IncreaseScore(scorePerHit);
    }
}
