using System.Collections;
using UnityEngine;

public class BlackHoleAbilityController : MonoBehaviour
{
    public GameObject blackHoleRadiusPrefab;

    public PlayerController player;

    public bool canUseBlackHole;

    public float maxRadius = 10f;

    private float blackHoleCooldown = 100f;
    public float blackHoleCooldownLeft;

    private float coolDownReduction;


    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        if (MainManager.Instance != null)
        {
            coolDownReduction = MainManager.Instance.playerCdr == 0 ? 0.0f : MainManager.Instance.playerCdr;

            if (coolDownReduction != 0)
            {
                blackHoleCooldown = (int)(blackHoleCooldown * (coolDownReduction / 100.0f));
            }
        }

        canUseBlackHole = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && canUseBlackHole)
        {
            MainManager.Instance.useBlackHoleQuestProgress++;
            canUseBlackHole = false;
            BlackHole();
            blackHoleCooldownLeft = blackHoleCooldown;
        }
    }

    public void BlackHole()
    {
        Vector2 point = GetSummonPoint();
        Instantiate(blackHoleRadiusPrefab, point, blackHoleRadiusPrefab.transform.rotation);

        StartCoroutine(Cooldown());
        StartCoroutine(SecondsLeft());
    }

    public Vector2 GetSummonPoint()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 offset = mouseWorldPos - (Vector2)player.transform.position;

        if (offset.magnitude > maxRadius)
        {
            offset = offset.normalized * maxRadius;
        }

        Vector2 finalPosition = (Vector2)player.transform.position + offset;

        return finalPosition;
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(blackHoleCooldown);
        canUseBlackHole = true;
    }

    private IEnumerator SecondsLeft()
    {
        while (!canUseBlackHole)
        {
            yield return new WaitForSeconds(1);
            blackHoleCooldownLeft -= 1;
        }
    }
}
