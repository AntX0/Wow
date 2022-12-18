using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
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
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parentGameObject.transform;
            Destroy(gameObject);
            scoreBoard.IncreaseScore(scorePerHit);
        }
    }

    private void ProcessHit()
    {
        enemyHealthPoints -= 30f;
        Debug.Log(enemyHealthPoints);
    }
}
