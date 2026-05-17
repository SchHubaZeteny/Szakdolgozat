using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PortalPlayerMoveController : MonoBehaviour
{
    private Vector2 destination;

    public bool portalOneEntered;
    public bool portalTwoEntered;

    public bool portalOnCooldown;

    public GameObject player;

    public bool startRoutineOnce = true;

    private float teleportSpeed = 40.0f;

    private float cooldown = 30.0f;

    private float secondsLeft;

    public TextMeshPro cooldownOneText;
    public TextMeshPro cooldownTwoText;

    public GameObject cooldownOneTextGameObject;
    public GameObject cooldownTwoTextGameObject;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        secondsLeft = cooldown;
    }

    void Update()
    {
        StartRoutine();
        UpdateTeleportOneText();
        UpdateTeleportTwoText();
    }

    void FixedUpdate()
    {
        MovingToTeleport();
    }

    IEnumerator TeleportCooldown()
    {
        StartCoroutine(CooldownCountdown());

        cooldownOneTextGameObject.SetActive(true);
        cooldownTwoTextGameObject.SetActive(true);

        yield return new WaitForSeconds(cooldown);

        cooldownOneTextGameObject.SetActive(false);
        cooldownTwoTextGameObject.SetActive(false);

        secondsLeft = cooldown;
        portalOnCooldown = false;
        startRoutineOnce = true;
    }

    IEnumerator CooldownCountdown()
    {
        while (portalOnCooldown)
        {
            yield return new WaitForSeconds(1);
            secondsLeft--;
        }
    }

    public void UpdateTeleportOneText()
    {
        cooldownOneText.text = $"{secondsLeft}";
    }

    public void UpdateTeleportTwoText()
    {
        cooldownTwoText.text = $"{secondsLeft}";
    }

    public void StartRoutine()
    {
        if(portalOnCooldown && startRoutineOnce)
        {
            startRoutineOnce = false;
            player.transform.GetChild(0).gameObject.SetActive(false);
            player.transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(TeleportCooldown());
        }
    }

    public void MovingToTeleport()
    {
        if (portalOneEntered)
        {
            destination = GameObject.FindWithTag("PortalTwo").transform.position;
            player.transform.position = Vector2.MoveTowards(player.transform.position, destination, teleportSpeed * Time.deltaTime);
        }
        if (portalTwoEntered)
        {
            destination = GameObject.FindWithTag("PortalOne").transform.position;
            player.transform.position = Vector2.MoveTowards(player.transform.position, destination, teleportSpeed * Time.deltaTime);
        }
    }
}
