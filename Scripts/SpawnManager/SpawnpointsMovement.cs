using UnityEngine;

public class SpawnpointsMovement : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position = player.transform.position;
    }
}
