using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public float musicVolume;
    public float soundFXVolume;

    public float playerGold;

    public int playerMaxHealth;
    public int hpLevel;

    public int dmgLevel;
    public int playerDamage;

    public int asLevel;
    public float playerAttackSpeed;

    public int speedLevel;
    public float playerSpeed;

    public int xpLevel;
    public float playerXp;

    public int goldLevel;
    public float playerGoldM;

    public int critLevel;
    public float playerCrit;

    public int cdrLevel;
    public float playerCdr;

    public bool playerMap1Completed;
    public bool playerMap2Completed;
    public bool playerMap3Completed;

    public int killEnemiesQuestProgress;
    public bool killEnemiesQuestCompleted;
    public int killEnemiesQuestLevel;

    public int useDashQuestProgress;
    public bool useDashQuestCompleted;
    public int useDashQuestLevel;

    public int useKnockbackQuestProgress;
    public bool useKnockbackQuestCompleted;
    public int useKnockbackQuestLevel;

    public int useBlackHoleQuestProgress;
    public bool useBlackHoleQuestCompleted;
    public int useBlackHoleQuestLevel;

    public int completeFirstMapQuestProgress;
    public bool completeFirstMapQuestCompleted;
    public int completeFirstMapQuestLevel;

    public int completeSecondMapQuestProgress;
    public bool completeSecondMapQuestCompleted;
    public int completeSecondMapQuestLevel;

    public int completeThirdMapQuestProgress;
    public bool completeThirdMapQuestCompleted;
    public int completeThirdMapQuestLevel;

    public int lifestealTonicQuantity;
    public bool usingLifestealTonic;

    public int explodeTonicQuantity;
    public bool usingExplodeTonic;

    public int goldHealTonicQuantity;
    public bool usingGoldHealTonic;

    public int goldDropTonicQuantity;
    public bool usingGoldDropTonic;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public float musicVolume;
        public float soundFXVolume;

        public float playerGold;

        public int playerMaxHealth;
        public int hpLevel;

        public int dmgLevel;
        public int playerDamage;

        public int asLevel;
        public float playerAttackSpeed;

        public int speedLevel;
        public float playerSpeed;

        public int xpLevel;
        public float playerXp;

        public int goldLevel;
        public float playerGoldM;

        public int critLevel;
        public float playerCrit;

        public int cdrLevel;
        public float playerCdr;

        public bool playerMap1Completed;
        public bool playerMap2Completed;
        public bool playerMap3Completed;

        public int killEnemiesQuestProgress;
        public bool killEnemiesQuestCompleted;
        public int killEnemiesQuestLevel;

        public int useDashQuestProgress;
        public bool useDashQuestCompleted;
        public int useDashQuestLevel;

        public int useKnockbackQuestProgress;
        public bool useKnockbackQuestCompleted;
        public int useKnockbackQuestLevel;

        public int useBlackHoleQuestProgress;
        public bool useBlackHoleQuestCompleted;
        public int useBlackHoleQuestLevel;

        public int completeFirstMapQuestProgress;
        public bool completeFirstMapQuestCompleted;
        public int completeFirstMapQuestLevel;

        public int completeSecondMapQuestProgress;
        public bool completeSecondMapQuestCompleted;
        public int completeSecondMapQuestLevel;

        public int completeThirdMapQuestProgress;
        public bool completeThirdMapQuestCompleted;
        public int completeThirdMapQuestLevel;

        public int lifestealTonicQuantity;
        public bool usingLifestealTonic;

        public int explodeTonicQuantity;
        public bool usingExplodeTonic;

        public int goldHealTonicQuantity;
        public bool usingGoldHealTonic;

        public int goldDropTonicQuantity;
        public bool usingGoldDropTonic;
    }

    public void SaveProgress()
    {
        SaveData data = new SaveData();
        data.musicVolume = musicVolume;
        data.soundFXVolume = soundFXVolume;

        data.playerGold = playerGold;
        data.playerMap1Completed = playerMap1Completed;
        data.playerMap2Completed = playerMap2Completed;
        data.playerMap3Completed = playerMap3Completed;
        data.hpLevel = hpLevel;
        data.playerMaxHealth = playerMaxHealth;
        data.dmgLevel = dmgLevel;
        data.playerDamage = playerDamage;
        data.asLevel = asLevel;
        data.playerAttackSpeed = playerAttackSpeed;
        data.speedLevel = speedLevel;
        data.playerSpeed = playerSpeed;
        data.xpLevel = xpLevel;
        data.playerXp = playerXp;
        data.goldLevel = goldLevel;
        data.playerGoldM = playerGoldM;
        data.critLevel = critLevel;
        data.playerCrit = playerCrit;
        data.cdrLevel = cdrLevel;
        data.playerCdr = playerCdr;

        data.killEnemiesQuestProgress = killEnemiesQuestProgress;
        data.killEnemiesQuestCompleted = killEnemiesQuestCompleted;
        data.killEnemiesQuestLevel = killEnemiesQuestLevel;

        data.useDashQuestProgress = useDashQuestProgress;
        data.useDashQuestCompleted = useDashQuestCompleted;
        data.useDashQuestLevel = useDashQuestLevel;

        data.useKnockbackQuestProgress = useKnockbackQuestProgress;
        data.useKnockbackQuestCompleted = useKnockbackQuestCompleted;
        data.useKnockbackQuestLevel = useKnockbackQuestLevel;

        data.useBlackHoleQuestProgress = useBlackHoleQuestProgress;
        data.useBlackHoleQuestCompleted = useBlackHoleQuestCompleted;
        data.useBlackHoleQuestLevel = useBlackHoleQuestLevel;

        data.completeFirstMapQuestProgress = completeFirstMapQuestProgress;
        data.completeFirstMapQuestCompleted = completeFirstMapQuestCompleted;
        data.completeFirstMapQuestLevel = completeFirstMapQuestLevel;

        data.completeSecondMapQuestProgress = completeSecondMapQuestProgress;
        data.completeSecondMapQuestCompleted = completeSecondMapQuestCompleted;
        data.completeSecondMapQuestLevel = completeSecondMapQuestLevel;

        data.completeThirdMapQuestProgress = completeThirdMapQuestProgress;
        data.completeThirdMapQuestCompleted = completeThirdMapQuestCompleted;
        data.completeThirdMapQuestLevel = completeThirdMapQuestLevel;

        data.lifestealTonicQuantity = lifestealTonicQuantity;
        data.usingLifestealTonic = usingLifestealTonic;
        data.explodeTonicQuantity = explodeTonicQuantity;
        data.usingExplodeTonic = usingExplodeTonic;
        data.goldHealTonicQuantity = goldHealTonicQuantity;
        data.usingGoldHealTonic = usingGoldHealTonic;
        data.goldDropTonicQuantity = goldDropTonicQuantity;
        data.usingGoldDropTonic = usingGoldDropTonic;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            musicVolume = data.musicVolume;
            soundFXVolume = data.soundFXVolume;

            playerGold = data.playerGold;
            playerMap1Completed = data.playerMap1Completed;
            playerMap2Completed = data.playerMap2Completed;
            playerMap3Completed = data.playerMap3Completed;
            hpLevel = data.hpLevel;
            playerMaxHealth = data.playerMaxHealth;
            dmgLevel = data.dmgLevel;
            playerDamage = data.playerDamage;
            asLevel = data.asLevel;
            playerAttackSpeed = data.playerAttackSpeed;
            speedLevel = data.speedLevel;
            playerSpeed = data.playerSpeed;
            xpLevel = data.xpLevel;
            playerXp = data.playerXp;
            goldLevel = data.goldLevel;
            playerGoldM = data.playerGoldM;
            critLevel = data.critLevel;
            playerCrit = data.playerCrit;
            cdrLevel = data.cdrLevel;
            playerCdr = data.playerCdr;

            killEnemiesQuestProgress = data.killEnemiesQuestProgress;
            killEnemiesQuestCompleted = data.killEnemiesQuestCompleted;
            killEnemiesQuestLevel = data.killEnemiesQuestLevel;

            useDashQuestProgress = data.useDashQuestProgress;
            useDashQuestCompleted = data.useDashQuestCompleted;
            useDashQuestLevel = data.useDashQuestLevel;

            useKnockbackQuestProgress = data.useKnockbackQuestProgress;
            useKnockbackQuestCompleted = data.useKnockbackQuestCompleted;
            useKnockbackQuestLevel = data.useKnockbackQuestLevel;

            useBlackHoleQuestProgress = data.useBlackHoleQuestProgress;
            useBlackHoleQuestCompleted = data.useBlackHoleQuestCompleted;
            useBlackHoleQuestLevel = data.useBlackHoleQuestLevel;

            completeFirstMapQuestProgress = data.completeFirstMapQuestProgress;
            completeFirstMapQuestCompleted = data.completeFirstMapQuestCompleted;
            completeFirstMapQuestLevel = data.completeFirstMapQuestLevel;

            completeSecondMapQuestProgress = data.completeSecondMapQuestProgress;
            completeSecondMapQuestCompleted = data.completeSecondMapQuestCompleted;
            completeSecondMapQuestLevel = data.completeSecondMapQuestLevel;

            completeThirdMapQuestProgress = data.completeThirdMapQuestProgress;
            completeThirdMapQuestCompleted = data.completeThirdMapQuestCompleted;
            completeThirdMapQuestLevel = data.completeThirdMapQuestLevel;

            lifestealTonicQuantity = data.lifestealTonicQuantity;
            usingLifestealTonic = data.usingLifestealTonic;
            explodeTonicQuantity = data.explodeTonicQuantity;
            usingExplodeTonic = data.usingExplodeTonic;
            goldHealTonicQuantity = data.goldHealTonicQuantity;
            usingGoldHealTonic = data.usingGoldHealTonic;
            goldDropTonicQuantity = data.goldDropTonicQuantity;
            usingGoldDropTonic = data.usingGoldDropTonic;
        }
    }
}




