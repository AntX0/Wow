using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] float timeTillDestroy = 3f;

    private void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}
