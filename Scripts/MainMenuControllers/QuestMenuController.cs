using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenuController : MonoBehaviour
{
    [Header("Kill Enemies Quest")]
    public int[] killEnemiesQuestProgressLevel = { 100, 500, 1000 };
    public int[] killEnemiesQuestRewardLevel = { 500, 1000, 2500 };
    public int killEnemiesQuestLevel = 0;
    public TextMeshProUGUI killEnemiesQuestDescriptionText;
    public TextMeshProUGUI killEnemiesQuestRewardText;
    public TextMeshProUGUI killEnemiesQuestProgressText;
    public GameObject killEnemiesQuestProgressBar;
    public GameObject killEnemiesQuestProgress;
    public GameObject killEnemiesQuestReward;
    public GameObject killEnemiesQuestCompletedText;
    public Image killEnemiesQuestProgressMask;

    [Header("Use Dash Ability Quest")]
    public int[] useDashQuestProgressLevel = { 10, 30, 50 };
    public int[] useDashQuestRewardLevel = { 500, 1000, 3000 };
    public int useDashQuestLevel = 0;
    public TextMeshProUGUI useDashQuestDescriptionText;
    public TextMeshProUGUI useDashQuestRewardText;
    public TextMeshProUGUI useDashQuestProgressText;
    public GameObject useDashQuestProgressBar;
    public GameObject useDashQuestProgress;
    public GameObject useDashQuestReward;
    public GameObject useDashQuestCompletedText;
    public Image useDashQuestProgressMask;

    [Header("Use Knockback Ability Quest")]
    public int[] useKnockbackQuestProgressLevel = { 10, 30, 50 };
    public int[] useKnockbackQuestRewardLevel = { 500, 1000, 3000 };
    public int useKnockbackQuestLevel = 0;
    public TextMeshProUGUI useKnockbackQuestDescriptionText;
    public TextMeshProUGUI useKnockbackQuestRewardText;
    public TextMeshProUGUI useKnockbackQuestProgressText;
    public GameObject useKnockbackQuestProgressBar;
    public GameObject useKnockbackQuestProgress;
    public GameObject useKnockbackQuestReward;
    public GameObject useKnockbackQuestCompletedText;
    public Image useKnockbackQuestProgressMask;

    [Header("Use BlackHole Ability Quest")]
    public int[] useBlackHoleQuestProgressLevel = { 10, 30, 50 };
    public int[] useBlackHoleQuestRewardLevel = { 1000, 2000, 4000 };
    public int useBlackHoleQuestLevel = 0;
    public TextMeshProUGUI useBlackHoleQuestDescriptionText;
    public TextMeshProUGUI useBlackHoleQuestRewardText;
    public TextMeshProUGUI useBlackHoleQuestProgressText;
    public GameObject useBlackHoleQuestProgressBar;
    public GameObject useBlackHoleQuestProgress;
    public GameObject useBlackHoleQuestReward;
    public GameObject useBlackHoleQuestCompletedText;
    public Image useBlackHoleQuestProgressMask;

    [Header("Complete The First Map Quest")]
    public int[] completeFirstMapQuestProgressLevel = { 10, 30, 50 };
    public int[] completeFirstMapQuestRewardLevel = { 500, 1000, 3000 };
    public int completeFirstMapQuestLevel = 0;
    public TextMeshProUGUI completeFirstMapQuestDescriptionText;
    public TextMeshProUGUI completeFirstMapQuestRewardText;
    public TextMeshProUGUI completeFirstMapQuestProgressText;
    public GameObject completeFirstMapQuestProgressBar;
    public GameObject completeFirstMapQuestProgress;
    public GameObject completeFirstMapQuestReward;
    public GameObject completeFirstMapQuestCompletedText;
    public Image completeFirstMapQuestProgressMask;

    [Header("Complete The Second Map Quest")]
    public int[] completeSecondMapQuestProgressLevel = { 10, 30, 50 };
    public int[] completeSecondMapQuestRewardLevel = { 1000, 2000, 4000 };
    public int completeSecondMapQuestLevel = 0;
    public TextMeshProUGUI completeSecondMapQuestDescriptionText;
    public TextMeshProUGUI completeSecondMapQuestRewardText;
    public TextMeshProUGUI completeSecondMapQuestProgressText;
    public GameObject completeSecondMapQuestProgressBar;
    public GameObject completeSecondMapQuestProgress;
    public GameObject completeSecondMapQuestReward;
    public GameObject completeSecondMapQuestCompletedText;
    public Image completeSecondMapQuestProgressMask;

    [Header("Complete The Third Map Quest")]
    public int[] completeThirdMapQuestProgressLevel = { 10, 30, 50 };
    public int[] completeThirdMapQuestRewardLevel = { 2000, 4000, 8000 };
    public int completeThirdMapQuestLevel = 0;
    public TextMeshProUGUI completeThirdMapQuestDescriptionText;
    public TextMeshProUGUI completeThirdMapQuestRewardText;
    public TextMeshProUGUI completeThirdMapQuestProgressText;
    public GameObject completeThirdMapQuestProgressBar;
    public GameObject completeThirdMapQuestProgress;
    public GameObject completeThirdMapQuestReward;
    public GameObject completeThirdMapQuestCompletedText;
    public Image completeThirdMapQuestProgressMask;



    void Start()
    {
        killEnemiesQuestLevel = MainManager.Instance.killEnemiesQuestLevel;
        useDashQuestLevel = MainManager.Instance.useDashQuestLevel;
        useKnockbackQuestLevel = MainManager.Instance.useKnockbackQuestLevel;
        completeFirstMapQuestLevel = MainManager.Instance.completeFirstMapQuestLevel;

        GetCurrentKillEnemiesQuestFill();
        UpdateKillEnemiesQuest();

        GetCurrentUseDashQuestFill();
        UpdateUseDashQuest();

        GetCurrentUseKnockbackQuestFill();
        UpdateUseKnockbackQuest();

        GetCurrentUseBlackHoleQuestFill();
        UpdateUseBlackHoleQuest();

        GetCurrentCompleteFirstMapQuestFill();
        UpdateCompleteFirstMapQuest();

        GetCurrentCompleteSecondMapQuestFill();
        UpdateCompleteSecondMapQuest();

        GetCurrentCompleteThirdMapQuestFill();
        UpdateCompleteThirdMapQuest();
    }


    void Update()
    {
        
    }

    #region KillEnemiesQuest
    public void UpdateKillEnemiesQuest()
    {
        if(MainManager.Instance.killEnemiesQuestCompleted)
        {
            killEnemiesQuestProgressBar.SetActive(false);
            killEnemiesQuestReward.SetActive(false);
            killEnemiesQuestProgress.SetActive(false);
            killEnemiesQuestCompletedText.SetActive(true);
        }

        if(killEnemiesQuestLevel < killEnemiesQuestProgressLevel.Length)
        {
            killEnemiesQuestDescriptionText.text = $"Kill {killEnemiesQuestProgressLevel[killEnemiesQuestLevel]} enemies";
            killEnemiesQuestRewardText.text = $"Reward: {killEnemiesQuestRewardLevel[killEnemiesQuestLevel]} gold";
            killEnemiesQuestProgressText.text = $"{MainManager.Instance.killEnemiesQuestProgress}/{killEnemiesQuestProgressLevel[killEnemiesQuestLevel]}";

            if (killEnemiesQuestProgressLevel[killEnemiesQuestLevel] <= MainManager.Instance.killEnemiesQuestProgress)
            {
                MainManager.Instance.playerGold += killEnemiesQuestRewardLevel[killEnemiesQuestLevel];
                killEnemiesQuestLevel++;
                MainManager.Instance.killEnemiesQuestLevel = killEnemiesQuestLevel;
                MainManager.Instance.killEnemiesQuestProgress = 0;
                MainManager.Instance.SaveProgress();
            }
        }else
        {
            MainManager.Instance.killEnemiesQuestCompleted = true;
            MainManager.Instance.SaveProgress();
        }


    }

    public void GetCurrentKillEnemiesQuestFill()
    {
        if(killEnemiesQuestLevel < killEnemiesQuestProgressLevel.Length)
        {
            float fillAmount = (float)MainManager.Instance.killEnemiesQuestProgress / (float)killEnemiesQuestProgressLevel[killEnemiesQuestLevel];
            killEnemiesQuestProgressMask.fillAmount = fillAmount;
        }
    }
    #endregion

    #region UseDashQuest
    public void UpdateUseDashQuest()
    {
        if (MainManager.Instance.useDashQuestCompleted)
        {
            useDashQuestProgressBar.SetActive(false);
            useDashQuestReward.SetActive(false);
            useDashQuestProgress.SetActive(false);
            useDashQuestCompletedText.SetActive(true);
        }

        if (useDashQuestLevel < useDashQuestProgressLevel.Length)
        {
            useDashQuestDescriptionText.text = $"Use the Dash ability {useDashQuestProgressLevel[useDashQuestLevel]} times";
            useDashQuestRewardText.text = $"Reward: {useDashQuestRewardLevel[useDashQuestLevel]} gold";
            useDashQuestProgressText.text = $"{MainManager.Instance.useDashQuestProgress}/{useDashQuestProgressLevel[useDashQuestLevel]}";

            if (useDashQuestProgressLevel[useDashQuestLevel] <= MainManager.Instance.useDashQuestProgress)
            {
                MainManager.Instance.playerGold += useDashQuestRewardLevel[useDashQuestLevel];
                useDashQuestLevel++;
                MainManager.Instance.useDashQuestLevel = useDashQuestLevel;
                MainManager.Instance.useDashQuestProgress = 0;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            MainManager.Instance.useDashQuestCompleted = true;
            MainManager.Instance.SaveProgress();
        }


    }

    public void GetCurrentUseDashQuestFill()
    {
        if (useDashQuestLevel < useDashQuestProgressLevel.Length)
        {
            float fillAmount = (float)MainManager.Instance.useDashQuestProgress / (float)useDashQuestProgressLevel[useDashQuestLevel];
            useDashQuestProgressMask.fillAmount = fillAmount;
        }
    }
    #endregion

    #region UseKnockbackQuest
    public void UpdateUseKnockbackQuest()
    {
        if (MainManager.Instance.useKnockbackQuestCompleted)
        {
            useKnockbackQuestProgressBar.SetActive(false);
            useKnockbackQuestReward.SetActive(false);
            useKnockbackQuestProgress.SetActive(false);
            useKnockbackQuestCompletedText.SetActive(true);
        }

        if (useKnockbackQuestLevel < useKnockbackQuestProgressLevel.Length)
        {
            useKnockbackQuestDescriptionText.text = $"Use the Knockback ability {useKnockbackQuestProgressLevel[useKnockbackQuestLevel]} times";
            useKnockbackQuestRewardText.text = $"Reward: {useKnockbackQuestRewardLevel[useKnockbackQuestLevel]} gold";
            useKnockbackQuestProgressText.text = $"{MainManager.Instance.useKnockbackQuestProgress}/{useKnockbackQuestProgressLevel[useKnockbackQuestLevel]}";

            if (useKnockbackQuestProgressLevel[useKnockbackQuestLevel] <= MainManager.Instance.useKnockbackQuestProgress)
            {
                MainManager.Instance.playerGold += useKnockbackQuestRewardLevel[useKnockbackQuestLevel];
                useKnockbackQuestLevel++;
                MainManager.Instance.useKnockbackQuestLevel = useKnockbackQuestLevel;
                MainManager.Instance.useKnockbackQuestProgress = 0;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            MainManager.Instance.useKnockbackQuestCompleted = true;
            MainManager.Instance.SaveProgress();
        }


    }

    public void GetCurrentUseKnockbackQuestFill()
    {
        if (useKnockbackQuestLevel < useKnockbackQuestProgressLevel.Length)
        {
            float fillAmount = (float)MainManager.Instance.useKnockbackQuestProgress / (float)useKnockbackQuestProgressLevel[useKnockbackQuestLevel];
            useKnockbackQuestProgressMask.fillAmount = fillAmount;
        }
    }
    #endregion

    #region UseBlackHoleQuest
    public void UpdateUseBlackHoleQuest()
    {
        if (MainManager.Instance.useBlackHoleQuestCompleted)
        {
            useBlackHoleQuestProgressBar.SetActive(false);
            useBlackHoleQuestReward.SetActive(false);
            useBlackHoleQuestProgress.SetActive(false);
            useBlackHoleQuestCompletedText.SetActive(true);
        }

        if (useBlackHoleQuestLevel < useBlackHoleQuestProgressLevel.Length)
        {
            useBlackHoleQuestDescriptionText.text = $"Use the Black Hole ability {useBlackHoleQuestProgressLevel[useBlackHoleQuestLevel]} times";
            useBlackHoleQuestRewardText.text = $"Reward: {useBlackHoleQuestRewardLevel[useBlackHoleQuestLevel]} gold";
            useBlackHoleQuestProgressText.text = $"{MainManager.Instance.useBlackHoleQuestProgress}/{useBlackHoleQuestProgressLevel[useBlackHoleQuestLevel]}";

            if (useBlackHoleQuestProgressLevel[useBlackHoleQuestLevel] <= MainManager.Instance.useBlackHoleQuestProgress)
            {
                MainManager.Instance.playerGold += useBlackHoleQuestRewardLevel[useBlackHoleQuestLevel];
                useBlackHoleQuestLevel++;
                MainManager.Instance.useBlackHoleQuestLevel = useBlackHoleQuestLevel;
                MainManager.Instance.useBlackHoleQuestProgress = 0;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            MainManager.Instance.useBlackHoleQuestCompleted = true;
            MainManager.Instance.SaveProgress();
        }


    }

    public void GetCurrentUseBlackHoleQuestFill()
    {
        if (useBlackHoleQuestLevel < useBlackHoleQuestProgressLevel.Length)
        {
            float fillAmount = (float)MainManager.Instance.useBlackHoleQuestProgress / (float)useBlackHoleQuestProgressLevel[useBlackHoleQuestLevel];
            useBlackHoleQuestProgressMask.fillAmount = fillAmount;
        }
    }
    #endregion

    #region CompleteFirstMapQuest
    public void UpdateCompleteFirstMapQuest()
    {
        if (MainManager.Instance.completeFirstMapQuestCompleted)
        {
            completeFirstMapQuestProgressBar.SetActive(false);
            completeFirstMapQuestReward.SetActive(false);
            completeFirstMapQuestProgress.SetActive(false);
            completeFirstMapQuestCompletedText.SetActive(true);
        }

        if (completeFirstMapQuestLevel < completeFirstMapQuestProgressLevel.Length)
        {
            completeFirstMapQuestDescriptionText.text = $"Complete the Undergrounds {completeFirstMapQuestProgressLevel[completeFirstMapQuestLevel]} times";
            completeFirstMapQuestRewardText.text = $"Reward: {completeFirstMapQuestRewardLevel[completeFirstMapQuestLevel]} gold";
            completeFirstMapQuestProgressText.text = $"{MainManager.Instance.completeFirstMapQuestProgress}/{completeFirstMapQuestProgressLevel[completeFirstMapQuestLevel]}";

            if (completeFirstMapQuestProgressLevel[completeFirstMapQuestLevel] <= MainManager.Instance.completeFirstMapQuestProgress)
            {
                MainManager.Instance.playerGold += completeFirstMapQuestRewardLevel[completeFirstMapQuestLevel];
                completeFirstMapQuestLevel++;
                MainManager.Instance.completeFirstMapQuestLevel = completeFirstMapQuestLevel;
                MainManager.Instance.completeFirstMapQuestProgress = 0;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            MainManager.Instance.completeFirstMapQuestCompleted = true;
            MainManager.Instance.SaveProgress();
        }


    }

    public void GetCurrentCompleteFirstMapQuestFill()
    {
        if (completeFirstMapQuestLevel < completeFirstMapQuestProgressLevel.Length)
        {
            float fillAmount = (float)MainManager.Instance.completeFirstMapQuestProgress / (float)completeFirstMapQuestProgressLevel[completeFirstMapQuestLevel];
            completeFirstMapQuestProgressMask.fillAmount = fillAmount;
        }
    }
    #endregion

    #region CompleteSecondMapQuest
    public void UpdateCompleteSecondMapQuest()
    {
        if (MainManager.Instance.completeSecondMapQuestCompleted)
        {
            completeSecondMapQuestProgressBar.SetActive(false);
            completeSecondMapQuestReward.SetActive(false);
            completeSecondMapQuestProgress.SetActive(false);
            completeSecondMapQuestCompletedText.SetActive(true);
        }

        if (completeSecondMapQuestLevel < completeSecondMapQuestProgressLevel.Length)
        {
            completeSecondMapQuestDescriptionText.text = $"Complete the Upper floors {completeSecondMapQuestProgressLevel[completeSecondMapQuestLevel]} times";
            completeSecondMapQuestRewardText.text = $"Reward: {completeSecondMapQuestRewardLevel[completeSecondMapQuestLevel]} gold";
            completeSecondMapQuestProgressText.text = $"{MainManager.Instance.completeSecondMapQuestProgress}/{completeSecondMapQuestProgressLevel[completeSecondMapQuestLevel]}";

            if (completeSecondMapQuestProgressLevel[completeSecondMapQuestLevel] <= MainManager.Instance.completeSecondMapQuestProgress)
            {
                MainManager.Instance.playerGold += completeSecondMapQuestRewardLevel[completeSecondMapQuestLevel];
                completeSecondMapQuestLevel++;
                MainManager.Instance.completeSecondMapQuestLevel = completeSecondMapQuestLevel;
                MainManager.Instance.completeSecondMapQuestProgress = 0;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            MainManager.Instance.completeSecondMapQuestCompleted = true;
            MainManager.Instance.SaveProgress();
        }


    }

    public void GetCurrentCompleteSecondMapQuestFill()
    {
        if (completeSecondMapQuestLevel < completeSecondMapQuestProgressLevel.Length)
        {
            float fillAmount = (float)MainManager.Instance.completeSecondMapQuestProgress / (float)completeSecondMapQuestProgressLevel[completeSecondMapQuestLevel];
            completeSecondMapQuestProgressMask.fillAmount = fillAmount;
        }
    }
    #endregion

    #region CompleteThirdMapQuest
    public void UpdateCompleteThirdMapQuest()
    {
        if (MainManager.Instance.completeThirdMapQuestCompleted)
        {
            completeThirdMapQuestProgressBar.SetActive(false);
            completeThirdMapQuestReward.SetActive(false);
            completeThirdMapQuestProgress.SetActive(false);
            completeThirdMapQuestCompletedText.SetActive(true);
        }

        if (completeThirdMapQuestLevel < completeThirdMapQuestProgressLevel.Length)
        {
            completeThirdMapQuestDescriptionText.text = $"Complete The Castle {completeThirdMapQuestProgressLevel[completeThirdMapQuestLevel]} times";
            completeThirdMapQuestRewardText.text = $"Reward: {completeThirdMapQuestRewardLevel[completeThirdMapQuestLevel]} gold";
            completeThirdMapQuestProgressText.text = $"{MainManager.Instance.completeThirdMapQuestProgress}/{completeThirdMapQuestProgressLevel[completeThirdMapQuestLevel]}";

            if (completeThirdMapQuestProgressLevel[completeThirdMapQuestLevel] <= MainManager.Instance.completeThirdMapQuestProgress)
            {
                MainManager.Instance.playerGold += completeThirdMapQuestRewardLevel[completeThirdMapQuestLevel];
                completeThirdMapQuestLevel++;
                MainManager.Instance.completeThirdMapQuestLevel = completeThirdMapQuestLevel;
                MainManager.Instance.completeThirdMapQuestProgress = 0;
                MainManager.Instance.SaveProgress();
            }
        }
        else
        {
            MainManager.Instance.completeThirdMapQuestCompleted = true;
            MainManager.Instance.SaveProgress();
        }


    }

    public void GetCurrentCompleteThirdMapQuestFill()
    {
        if (completeThirdMapQuestLevel < completeThirdMapQuestProgressLevel.Length)
        {
            float fillAmount = (float)MainManager.Instance.completeThirdMapQuestProgress / (float)completeThirdMapQuestProgressLevel[completeThirdMapQuestLevel];
            completeThirdMapQuestProgressMask.fillAmount = fillAmount;
        }
    }
    #endregion

}
