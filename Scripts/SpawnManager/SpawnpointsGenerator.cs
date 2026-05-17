using UnityEngine;

public class SpawnpointsGenerator : MonoBehaviour
{
    public GameObject circlePrefab; 
    public GameObject parent;

    public SpawnManager spawnManager;

    private int countOne = 80;       
    private float radiusOne = 21f;    

    private void Start()
    {
        spawnManager = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>();

        Generate(radiusOne, countOne);
    }

    public void Generate(float radius, float count)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = i * Mathf.PI * 2f / count;

            Vector2 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            GameObject child = Instantiate(circlePrefab, (Vector2)transform.position + pos, Quaternion.identity);

            child.transform.parent = parent.transform;

            spawnManager.spawnpoints.Add(child);
        }
    }
}
