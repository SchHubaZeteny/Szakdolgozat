using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAbilityController : MonoBehaviour
{
    public GameMenuManager gameMenuManager;
    public GameObject abilitiesParent;

    private int indexOfAbilityOne;
    private int indexOfAbilityTwo;
    private int indexOfAbilityThree;

    private string chosenAbilityOne;
    private string chosenAbilityTwo;
    private string chosenAbilityThree;

    private int countdown = 20;
    private int secondsLeft;
    private int randomChoose;
    public TextMeshProUGUI countdownText;

    public bool settingAbility = true;

    public int abilitiesLength;

    [Header("Abilities")]
    private List<string> abilityNames = new List<string>()
    {
        "OrbitalAbility",
        "FreezeAbility",
        "BombAbility",
        "ChainLightningAbility",
        "BoomerangAbility",
        "BigCircleDamageAbility",
        "FireCircleAbility",
        "LightningCastAbility"
    };

    private Dictionary<string, string> abilityTexts = new Dictionary<string, string>()
    {
        {"OrbitalAbility", "Orbiting rune" },
        {"FreezeAbility", "Circle of freeze" },
        {"BombAbility", "Crafted bomb" },
        {"ChainLightningAbility", "Chainlightning" },
        {"BoomerangAbility", "Elven sword" },
        {"BigCircleDamageAbility", "Circle of annihilation" },
        {"FireCircleAbility", "Circle of fire" },
        {"LightningCastAbility", "Touch of lightning" }
    };

    [Header("Choose Name Texts")]
    public TextMeshProUGUI abilityOneNameText;
    public TextMeshProUGUI abilityTwoNameText;
    public TextMeshProUGUI abilityThreeNameText;

    [Header("Ability Images")]
    public Image abilityOneImage;
    public Image abilityTwoImage;
    public Image abilityThreeImage;

    [Header("Images")]
    public Sprite orbitalAbilityImage;
    public Sprite freezeAbilityImage;
    public Sprite bombAbilityImage;
    public Sprite chainLightningAbilityImage;
    public Sprite boomerangAbilityImage;
    public Sprite bigCircleDamageAbilityImage;
    public Sprite fireCircleAbilityImage;
    public Sprite lightningCastAbilityImage;

    public Dictionary<string, Sprite> abilityImages;

    void Start()
    {
        gameMenuManager = GameObject.FindWithTag("GameMenuManager").GetComponent<GameMenuManager>();
        abilityImages = new Dictionary<string, Sprite>()
        {
            { "OrbitalAbility", orbitalAbilityImage },
            { "FreezeAbility", freezeAbilityImage },
            { "BombAbility", bombAbilityImage },
            { "ChainLightningAbility", chainLightningAbilityImage },
            { "BoomerangAbility", boomerangAbilityImage },
            { "BigCircleDamageAbility", bigCircleDamageAbilityImage },
            { "FireCircleAbility", fireCircleAbilityImage },
            { "LightningCastAbility", lightningCastAbilityImage }

        };
    }

    void Update()
    {
        SettingChooseAbilities();
        CountdownText();
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSecondsRealtime(countdown);
        secondsLeft = countdown;
        RandomChoose();
    }

    IEnumerator SecondsLeft()
    {
        while(countdown != 0)
        {
            yield return new WaitForSecondsRealtime(1);
            secondsLeft--;
        }
    }

    public void CountdownText()
    {
        if(secondsLeft <= 10)
        {
            countdownText.color = Color.red;
        }
        else
        {
            countdownText.color = Color.white;
        }
            countdownText.text = $"{secondsLeft}";
    }

    public void RandomChoose()
    {
        if(randomChoose == 1)
        {
            Choose1();
        }else if(randomChoose == 2)
        {
            Choose2();
        }else if(randomChoose == 3)
        {
            Choose3();
        }
    }

    public void SettingChooseAbilities()
    {
        if(gameMenuManager.gameLevelUpPause && settingAbility)
        {
            randomChoose = Random.Range(1, 3);
            secondsLeft = countdown;
            StartCoroutine(Countdown());
            StartCoroutine(SecondsLeft());

            int randomOne = 0;
            int randomTwo = 0;
            int randomThree = 0;

            string abilityOneName;
            string abilityTwoName;
            string abilityThreeName;

            abilitiesLength = abilityNames.Count;

            while (true || Time.deltaTime == Time.deltaTime + 20)
            {
                randomOne = Random.Range(0, abilitiesLength);
                randomTwo = Random.Range(0, abilitiesLength);
                randomThree = Random.Range(0, abilitiesLength);

                if(randomOne != randomTwo && randomOne != randomThree && randomTwo != randomThree)
                {
                    break;
                }
            }

            chosenAbilityOne = abilityNames[randomOne];
            chosenAbilityTwo = abilityNames[randomTwo];
            chosenAbilityThree = abilityNames[randomThree];

            abilityOneName = abilityTexts[chosenAbilityOne];
            abilityTwoName = abilityTexts[chosenAbilityTwo];
            abilityThreeName = abilityTexts[chosenAbilityThree];

            abilityOneImage.sprite = abilityImages[chosenAbilityOne];
            abilityTwoImage.sprite = abilityImages[chosenAbilityTwo];
            abilityThreeImage.sprite = abilityImages[chosenAbilityThree];

            abilityOneNameText.text = abilityOneName;
            abilityTwoNameText.text = abilityTwoName;
            abilityThreeNameText.text = abilityThreeName;

            for (int i = 0; i < abilitiesParent.transform.childCount; i++)
            {
                Transform child = abilitiesParent.transform.GetChild(i);

                string tag = child.tag;

                if(tag == chosenAbilityOne)
                {
                    indexOfAbilityOne = i;
                }else if(tag == chosenAbilityTwo)
                {
                    indexOfAbilityTwo = i;
                }
                else if(tag == chosenAbilityThree)
                {
                    indexOfAbilityThree = i;
                }
            }

            settingAbility = false;
        }
    }


    public void Choose1()
    {
        gameMenuManager.levelUpMenuUI.SetActive(false);
        gameMenuManager.gameLevelUpPause = false;
        settingAbility = true;
        abilitiesParent.transform.GetChild(indexOfAbilityOne).gameObject.SetActive(true);
        abilityNames.Remove(chosenAbilityOne);
        Time.timeScale = 1.0f;

        secondsLeft = countdown;
        StopAllCoroutines();
    }

    public void Choose2()
    {
        gameMenuManager.levelUpMenuUI.SetActive(false);
        gameMenuManager.gameLevelUpPause = false;
        settingAbility = true;
        abilitiesParent.transform.GetChild(indexOfAbilityTwo).gameObject.SetActive(true);
        abilityNames.Remove(chosenAbilityTwo);
        Time.timeScale = 1.0f;

        secondsLeft = countdown;
        StopAllCoroutines();
    }

    public void Choose3()
    {
        gameMenuManager.levelUpMenuUI.SetActive(false);
        gameMenuManager.gameLevelUpPause = false;
        settingAbility = true;
        abilitiesParent.transform.GetChild(indexOfAbilityThree).gameObject.SetActive(true);
        abilityNames.Remove(chosenAbilityThree);
        Time.timeScale = 1.0f;

        secondsLeft = countdown;
        StopAllCoroutines();
    }
}
