using UnityEngine;

public class SpawnpointController : MonoBehaviour
{
    public SpawnManager spawnManager;


    void Start()
    {
        spawnManager = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle") && spawnManager != null)
        {
            spawnManager.spawnpoints.Remove(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && spawnManager != null)
        {
            if (!spawnManager.spawnpoints.Contains(gameObject))
            {
                spawnManager.spawnpoints.Add(gameObject);
            }
        }
    }
}
