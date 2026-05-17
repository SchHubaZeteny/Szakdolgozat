using UnityEngine;
using UnityEngine.UIElements;

public class MoveSpawnPoints : MonoBehaviour
{
    private Vector2 offset;
    public string pos = "top";
    private float posFromPlayer = 15.0f;

    public GameObject player;


    void Start()
    {
        GetOffset();
    }

    // Update is called once per frame
    void Update()
    {
        MovePosition();
    }

    public void MovePosition()
    {
        GetOffset();
        transform.position = offset;
    }
    

    public Vector2 GetOffset()
    {
        switch(pos)
        {
            case "top": return offset = new Vector2(player.transform.position.x, player.transform.position.y + posFromPlayer);
            case "bottom": return offset = new Vector2(player.transform.position.x, player.transform.position.y - posFromPlayer);
            case "right": return offset = new Vector2(player.transform.position.x + posFromPlayer, player.transform.position.y);
            case "left": return offset = new Vector2(player.transform.position.x - posFromPlayer, player.transform.position.y);
            default: return new Vector2(0, 0);
        }
    }
    
}
