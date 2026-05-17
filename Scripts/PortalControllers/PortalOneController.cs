using System.Collections;
using TMPro;
using UnityEngine;

public class PortalOneController : MonoBehaviour
{
    public PortalPlayerMoveController controller;

    public GameObject player;

    void Start()
    {
        controller = GameObject.FindWithTag("PortalManager").GetComponent<PortalPlayerMoveController>();
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerPickUpHitbox") && !controller.portalOnCooldown)
        {
            controller.portalOnCooldown = true;
            controller.portalOneEntered = true;
            player.GetComponent<PlayerController>().isPortaling = true;
        }

        if(other.CompareTag("PlayerPickUpHitbox") && controller.portalOnCooldown && controller.portalTwoEntered)
        {
            controller.portalTwoEntered = false;
            player.transform.GetChild(0).gameObject.SetActive(true);
            player.transform.GetChild(1).gameObject.SetActive(true);
            player.GetComponent<PlayerController>().isPortaling = false;
        }
    }
}
