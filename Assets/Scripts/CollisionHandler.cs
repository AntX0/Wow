using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crashParticles;

    private void OnTriggerEnter(Collider other)
    {
        StartFailSequence();
    }

    private void StartFailSequence()
    {
        _crashParticles.Play();
        
        ActivateCrashAnimation();
        GetComponent<BoxCollider>().enabled= false;
        Invoke("RestartLevel", 1f);
        GetComponent<PlayerControls>().enabled = false;
    }

    private void ActivateCrashAnimation()
    {
       GetComponent<Animator>().enabled= true;
       GetComponent<Animator>().SetTrigger("Crash");
    }

    private void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
