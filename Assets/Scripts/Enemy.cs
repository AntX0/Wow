using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] float enemyHealthPoints = 100f;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("Spawn");
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
            vfx.transform.parent = parentGameObject.transform;
            Destroy(gameObject);
        }  
    }

    private void ProcessHit()
    {
        enemyHealthPoints -= 30f;
        Debug.Log(enemyHealthPoints);
        scoreBoard.IncreaseScore(scorePerHit);
    }
}
