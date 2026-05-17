using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int secondsLeft = 1200;

    public PlayerController player;
    public GameMenuManager gameMenuManager;

    void Start()
    {
        gameMenuManager = GameObject.FindWithTag("GameMenuManager").GetComponent<GameMenuManager>();

        if(MainManager.Instance == null)
        {
            SceneManager.LoadScene(0);
        }

        Time.timeScale = 1.0f;

        StartCoroutine(SecondsLeft());
    }

    public void CountSeconds()
    {
        StartCoroutine(SecondsLeft());
    }

    public IEnumerator SecondsLeft()
    {
        yield return new WaitForSeconds(1);

        secondsLeft -= 1;

        if(secondsLeft <= 0)
        {
            gameMenuManager.EnterWinMenu();
        }

        CountSeconds();
    }
}
