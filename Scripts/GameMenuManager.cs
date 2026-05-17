using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public bool gameIsPaused = false;
    public bool gameLevelUpPause = false;

    public bool isMapOne;
    public bool isMapTwo;
    public bool isMapThree;

    public GameObject pauseMenuUI;
    public GameObject winMenuUI;
    public GameObject loseMenuUI;
    public GameObject levelUpMenuUI;
    public GameManager gameManager;
    public PlayerController player;

    public AudioClip buttonClickSound;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        EnterPauseMenu();
    }

    public void EnterPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused && !gameLevelUpPause)
            {
                Resume();
            } else if (!gameLevelUpPause)
            {
                Pause();
            }   
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        MainManager.Instance.SaveProgress();
        SceneManager.LoadScene(0);
    }

    public void EnterWinMenu()
    {
        gameIsPaused = true;
        player.maxGold += player.gold;
        MainManager.Instance.playerGold = player.maxGold;

        if (isMapOne)
        {
            MainManager.Instance.completeFirstMapQuestProgress++;
            MainManager.Instance.playerMap1Completed = true;
        }else if (isMapTwo)
        {
            MainManager.Instance.completeSecondMapQuestProgress++;
            MainManager.Instance.playerMap2Completed = true;
        }
        else if (isMapThree)
        {
            MainManager.Instance.completeThirdMapQuestProgress++;
            MainManager.Instance.playerMap3Completed = true;
        }

        winMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void EnterLoseMenu()
    {
        Time.timeScale = 0.0f;
        gameIsPaused = true;
        loseMenuUI.SetActive(true);
    }

    public void EnterLevelUpMenu()
    {
        levelUpMenuUI.SetActive(true);
        gameLevelUpPause = true;
        gameIsPaused = true;
        Time.timeScale = 0.0f;
    }

    public void ButtonClickSoundPlay()
    {
        SoundFXManager.instance.PlaySoundFXClip(buttonClickSound, 0f, buttonClickSound.length, transform, 1f);
    }
}
