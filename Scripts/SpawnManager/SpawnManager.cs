using NUnit.Framework;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    private bool canSpawn = true;

    public bool isMapOne;
    public bool isMapTwo;
    public bool isMapThree;

    private float waveOneSpawnCooldown;
    private float waveOneTime;

    private float waveTwoSpawnCooldown;
    private float waveTwoTime;

    private float waveThreeSpawnCooldown;
    private float waveThreeTime;

    private float waveFourSpawnCooldown;
    private float waveFourTime;

    private float waveFiveSpawnCooldown;
    private float waveFiveTime;

    private float waveSixSpawnCooldown;
    private float waveSixTime;

    public GameObject[] enemyPrefabs;

    public List<GameObject> spawnpoints = new List<GameObject>();

    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (isMapOne)
        {
            waveOneSpawnCooldown = 10f;
            waveOneTime = 1000f;

            waveTwoSpawnCooldown = 10f;
            waveTwoTime = waveOneTime - 200f;

            waveThreeSpawnCooldown = 15f;
            waveThreeTime = waveTwoTime - 200f;

            waveFourSpawnCooldown = 15f;
            waveFourTime = waveThreeTime - 200f;

            waveFiveSpawnCooldown = 25f;
            waveFiveTime = waveFourTime - 200f;

            waveSixSpawnCooldown = 10f;
            waveSixTime = waveFiveTime - 200f;

            StartCoroutine(WaveOneMapOneSpawnCooldown());
        }

        if (isMapTwo)
        {
            waveOneSpawnCooldown = 15f;
            waveOneTime = 1000f;

            waveTwoSpawnCooldown = 10f;
            waveTwoTime = waveOneTime - 200f;

            waveThreeSpawnCooldown = 10f;
            waveThreeTime = waveTwoTime - 200f;

            waveFourSpawnCooldown = 20f;
            waveFourTime = waveThreeTime - 200f;

            waveFiveSpawnCooldown = 25f;
            waveFiveTime = waveFourTime - 200f;

            waveSixSpawnCooldown = 20f;
            waveSixTime = waveFiveTime - 200f;

            StartCoroutine(WaveOneMapTwoSpawnCooldown());
        }

        if (isMapThree)
        {
            waveOneSpawnCooldown = 15f;
            waveOneTime = 1000f;

            waveTwoSpawnCooldown = 15f;
            waveTwoTime = waveOneTime - 200f;

            waveThreeSpawnCooldown = 20f;
            waveThreeTime = waveTwoTime - 200f;

            waveFourSpawnCooldown = 20f;
            waveFourTime = waveThreeTime - 200f;

            waveFiveSpawnCooldown = 25f;
            waveFiveTime = waveFourTime - 200f;

            waveSixSpawnCooldown = 20f;
            waveSixTime = waveFiveTime - 200f;

            StartCoroutine(WaveOneMapThreeSpawnCooldown());
        }

    }

    #region MapOneSpawnManager
    public void WaveMapOneManager()
    {
        if (canSpawn)
        {
            if (gameManager.secondsLeft > waveOneTime)
            {
                WaveOneMapOne();
            }
            else if (gameManager.secondsLeft < waveOneTime && gameManager.secondsLeft > waveTwoTime)
            {
                WaveTwoMapOne();
            }
            else if (gameManager.secondsLeft < waveTwoTime && gameManager.secondsLeft > waveThreeTime)
            {
                WaveThreeMapOne();
            }
            else if (gameManager.secondsLeft < waveThreeTime && gameManager.secondsLeft > waveFourTime)
            {
                WaveFourMapOne();
            }
            else if (gameManager.secondsLeft < waveFourTime && gameManager.secondsLeft > waveFiveTime)
            {
                WaveFiveMapOne();
            }
            else if (gameManager.secondsLeft < waveFiveTime && gameManager.secondsLeft > waveSixTime)
            {
                WaveSixMapOne();
            }
        }
    }

    // Wave One
    public void WaveOneMapOne()
    {
        int randEnemyCount = Random.Range(1, 6);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveOneMapOneSpawnCooldown());
    }

    public IEnumerator WaveOneMapOneSpawnCooldown()
    {
        yield return new WaitForSeconds(waveOneSpawnCooldown);
        WaveMapOneManager();
    }

    // Wave Two
    public void WaveTwoMapOne()
    {
        int randEnemyCount = Random.Range(3, 9);
        int randFastEnemyCount = Random.Range(1, 4);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randFastEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[1], selectedPoint.transform.position, enemyPrefabs[1].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveTwoMapOneSpawnCooldown());
    }

    public IEnumerator WaveTwoMapOneSpawnCooldown()
    {
        yield return new WaitForSeconds(waveTwoSpawnCooldown);
        WaveMapOneManager();
    }

    // Wave Three
    public void WaveThreeMapOne()
    {
        int randEnemyCount = Random.Range(5, 11);
        int randFastEnemyCount = Random.Range(1, 3);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randFastEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[1], selectedPoint.transform.position, enemyPrefabs[1].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveThreeMapOneSpawnCooldown());
    }

    public IEnumerator WaveThreeMapOneSpawnCooldown()
    {
        yield return new WaitForSeconds(waveThreeSpawnCooldown);
        WaveMapOneManager();
    }

    // Wave Four
    public void WaveFourMapOne()
    {
        int randEnemyCount = Random.Range(2, 7);
        int randMediumEnemyCount = Random.Range(2, 6);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randMediumEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[2], selectedPoint.transform.position, enemyPrefabs[2].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveFourMapOneSpawnCooldown());
    }

    public IEnumerator WaveFourMapOneSpawnCooldown()
    {
        yield return new WaitForSeconds(waveFourSpawnCooldown);
        WaveMapOneManager();
    }

    // Wave Five
    public void WaveFiveMapOne()
    {
        int randSummonerEnemyCount = Random.Range(1, 3);
        int randMediumEnemyCount = Random.Range(1, 4);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randSummonerEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[4], selectedPoint.transform.position, enemyPrefabs[4].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randMediumEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[2], selectedPoint.transform.position, enemyPrefabs[2].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveFiveMapOneSpawnCooldown());
    }

    public IEnumerator WaveFiveMapOneSpawnCooldown()
    {
        yield return new WaitForSeconds(waveFiveSpawnCooldown);
        WaveMapOneManager();
    }

    // Wave Six
    public void WaveSixMapOne()
    {
        int randSummonerEnemyCount = Random.Range(2, 5);
        int randMediumEnemyCount = Random.Range(1, 4);
        int randFastEnemyCount = Random.Range(2, 5);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randSummonerEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[4], selectedPoint.transform.position, enemyPrefabs[4].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randMediumEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[2], selectedPoint.transform.position, enemyPrefabs[2].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randFastEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[1], selectedPoint.transform.position, enemyPrefabs[1].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveSixMapOneSpawnCooldown());
    }

    public IEnumerator WaveSixMapOneSpawnCooldown()
    {
        yield return new WaitForSeconds(waveSixSpawnCooldown);
        WaveMapOneManager();
    }

    #endregion


    #region MapTwoSpawnManager
    public void WaveMapTwoManager()
    {
        if (canSpawn)
        {
            if (gameManager.secondsLeft > waveOneTime)
            {
                WaveOneMapTwo();
            }
            else if (gameManager.secondsLeft < waveOneTime && gameManager.secondsLeft > waveTwoTime)
            {
                WaveTwoMapTwo();
            }
            else if (gameManager.secondsLeft < waveTwoTime && gameManager.secondsLeft > waveThreeTime)
            {
                WaveThreeMapTwo();
            }
            else if (gameManager.secondsLeft < waveThreeTime && gameManager.secondsLeft > waveFourTime)
            {
                WaveFourMapTwo();
            }
            else if (gameManager.secondsLeft < waveFourTime && gameManager.secondsLeft > waveFiveTime)
            {
                WaveFiveMapTwo();
            }
            else if (gameManager.secondsLeft < waveFiveTime && gameManager.secondsLeft > waveSixTime)
            {
                WaveSixMapTwo();
            }
        }
    }

    // Wave One
    public void WaveOneMapTwo()
    {
        int randEnemyCount = Random.Range(3, 6);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveOneMapTwoSpawnCooldown());
    }

    public IEnumerator WaveOneMapTwoSpawnCooldown()
    {
        yield return new WaitForSeconds(waveOneSpawnCooldown);
        WaveMapTwoManager();
    }

    // Wave Two
    public void WaveTwoMapTwo()
    {
        int randEnemyCount = Random.Range(5, 11);
        int randFastEnemyCount = Random.Range(1, 4);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randFastEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[1], selectedPoint.transform.position, enemyPrefabs[1].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveTwoMapTwoSpawnCooldown());
    }

    public IEnumerator WaveTwoMapTwoSpawnCooldown()
    {
        yield return new WaitForSeconds(waveTwoSpawnCooldown);
        WaveMapTwoManager();
    }

    // Wave Three
    public void WaveThreeMapTwo()
    {
        int randEnemyCount = Random.Range(5, 11);
        int bombEnemyCount = 1;

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < bombEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[5], selectedPoint.transform.position, enemyPrefabs[5].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveThreeMapTwoSpawnCooldown());
    }

    public IEnumerator WaveThreeMapTwoSpawnCooldown()
    {
        yield return new WaitForSeconds(waveThreeSpawnCooldown);
        WaveMapTwoManager();
    }

    // Wave Four
    public void WaveFourMapTwo()
    {
        int randEnemyCount = Random.Range(8, 12);
        int randSummonerEnemyCount = Random.Range(1, 3);
        int poisonousEnemyCount = Random.Range(1, 3);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randSummonerEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[4], selectedPoint.transform.position, enemyPrefabs[4].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < poisonousEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[3], selectedPoint.transform.position, enemyPrefabs[3].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveFourMapTwoSpawnCooldown());
    }

    public IEnumerator WaveFourMapTwoSpawnCooldown()
    {
        yield return new WaitForSeconds(waveFourSpawnCooldown);
        WaveMapTwoManager();
    }

    // Wave Five
    public void WaveFiveMapTwo()
    {
        int randMediumEnemyCount = Random.Range(2, 4);
        int randSummonerEnemyCount = Random.Range(2, 4);
        int randPoisonousEnemyCount = Random.Range(3, 5);
        int randBombEnemyCount = Random.Range(0, 2);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randMediumEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[2], selectedPoint.transform.position, enemyPrefabs[2].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randSummonerEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[4], selectedPoint.transform.position, enemyPrefabs[4].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randPoisonousEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[3], selectedPoint.transform.position, enemyPrefabs[3].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        for (int i = 0; i < randBombEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[5], selectedPoint.transform.position, enemyPrefabs[5].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveFiveMapTwoSpawnCooldown());
    }

    public IEnumerator WaveFiveMapTwoSpawnCooldown()
    {
        yield return new WaitForSeconds(waveFiveSpawnCooldown);
        WaveMapTwoManager();
    }

    // Wave Six
    public void WaveSixMapTwo()
    {
        int randEnemyCount = Random.Range(10, 15);
        int randMediumEnemyCount = Random.Range(3, 4);
        int randFastEnemyCount = Random.Range(3, 6);
        int randFastEnemy = Random.Range(3, 6);
        int randShootingEnemyCount = Random.Range(2, 5);
        int randPoisonousEnemyCount = Random.Range(4, 7);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randMediumEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[2], selectedPoint.transform.position, enemyPrefabs[2].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randFastEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[1], selectedPoint.transform.position, enemyPrefabs[1].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randShootingEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[6], selectedPoint.transform.position, enemyPrefabs[6].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randPoisonousEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[3], selectedPoint.transform.position, enemyPrefabs[3].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveSixMapTwoSpawnCooldown());
    }

    public IEnumerator WaveSixMapTwoSpawnCooldown()
    {
        yield return new WaitForSeconds(waveSixSpawnCooldown);
        WaveMapTwoManager();
    }



    #endregion


    #region MapThreeSpawnManager
    public void WaveMapThreeManager()
    {
        if (canSpawn)
        {
            if (gameManager.secondsLeft > waveOneTime)
            {
                WaveOneMapThree();
            }
            else if (gameManager.secondsLeft < waveOneTime && gameManager.secondsLeft > waveTwoTime)
            {
                WaveTwoMapThree();
            }
            else if (gameManager.secondsLeft < waveTwoTime && gameManager.secondsLeft > waveThreeTime)
            {
                WaveThreeMapThree();
            }
            else if (gameManager.secondsLeft < waveThreeTime && gameManager.secondsLeft > waveFourTime)
            {
                WaveFourMapThree();
            }
            else if (gameManager.secondsLeft < waveFourTime && gameManager.secondsLeft > waveFiveTime)
            {
                WaveFiveMapThree();
            }
            else if (gameManager.secondsLeft < waveFiveTime && gameManager.secondsLeft > waveSixTime)
            {
                WaveSixMapThree();
            }
        }
    }

    // Wave One
    public void WaveOneMapThree()
    {
        int randEnemyCount = Random.Range(10, 16);
        int randMediumEnemyCount = Random.Range(3, 6);
        int bombEnemyCount = 1;

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randMediumEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[2], selectedPoint.transform.position, enemyPrefabs[2].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < bombEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[5], selectedPoint.transform.position, enemyPrefabs[5].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveOneMapThreeSpawnCooldown());
    }

    public IEnumerator WaveOneMapThreeSpawnCooldown()
    {
        yield return new WaitForSeconds(waveOneSpawnCooldown);
        WaveMapThreeManager();
    }

    // Wave Two
    public void WaveTwoMapThree()
    {
        int randEnemyCount = Random.Range(10, 16);
        int randMediumEnemyCount = Random.Range(3, 6);
        int randPoisonousEnemyCount = Random.Range(3, 6);
        int randShootingEnemyCount = Random.Range(1, 4);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randMediumEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[2], selectedPoint.transform.position, enemyPrefabs[2].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randPoisonousEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[3], selectedPoint.transform.position, enemyPrefabs[3].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randShootingEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[6], selectedPoint.transform.position, enemyPrefabs[6].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveTwoMapThreeSpawnCooldown());
    }

    public IEnumerator WaveTwoMapThreeSpawnCooldown()
    {
        yield return new WaitForSeconds(waveTwoSpawnCooldown);
        WaveMapThreeManager();
    }

    // Wave Three
    public void WaveThreeMapThree()
    {
        int randShootingEnemyCount = Random.Range(3, 7);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randShootingEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[6], selectedPoint.transform.position, enemyPrefabs[6].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveThreeMapThreeSpawnCooldown());
    }

    public IEnumerator WaveThreeMapThreeSpawnCooldown()
    {
        yield return new WaitForSeconds(waveThreeSpawnCooldown);
        WaveMapThreeManager();
    }

    // Wave Four
    public void WaveFourMapThree()
    {
        int randShootingEnemyCount = Random.Range(3, 7);
        int randSummonerEnemyCount = Random.Range(3, 5);
        int randPoisonousEnemyCount = Random.Range(3, 5);
        int randMediumEnemyCount = Random.Range(4, 7);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randShootingEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[6], selectedPoint.transform.position, enemyPrefabs[6].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randSummonerEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[4], selectedPoint.transform.position, enemyPrefabs[4].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randPoisonousEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[3], selectedPoint.transform.position, enemyPrefabs[3].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randMediumEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[2], selectedPoint.transform.position, enemyPrefabs[2].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveFourMapThreeSpawnCooldown());
    }

    public IEnumerator WaveFourMapThreeSpawnCooldown()
    {
        yield return new WaitForSeconds(waveFourSpawnCooldown);
        WaveMapThreeManager();
    }

    // Wave Five
    public void WaveFiveMapThree()
    {
        int randShootingEnemyCount = Random.Range(3, 6);
        int randSummonerEnemyCount = Random.Range(3, 6);
        int randPoisonousEnemyCount = Random.Range(5, 8);
        int randMediumEnemyCount = Random.Range(1, 3);
        int randBombEnemyCount = Random.Range(0, 2);
        int randEnemyCount = Random.Range(5, 8);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randShootingEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[6], selectedPoint.transform.position, enemyPrefabs[6].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randSummonerEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[4], selectedPoint.transform.position, enemyPrefabs[4].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randPoisonousEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[3], selectedPoint.transform.position, enemyPrefabs[3].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randMediumEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[2], selectedPoint.transform.position, enemyPrefabs[2].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randBombEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[5], selectedPoint.transform.position, enemyPrefabs[5].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[0], selectedPoint.transform.position, enemyPrefabs[0].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveFiveMapThreeSpawnCooldown());
    }

    public IEnumerator WaveFiveMapThreeSpawnCooldown()
    {
        yield return new WaitForSeconds(waveFiveSpawnCooldown);
        WaveMapThreeManager();
    }

    // Wave Six
    public void WaveSixMapThree()
    {
        int randShootingEnemyCount = Random.Range(8, 13);
        int randSummonerEnemyCount = Random.Range(2, 5);
        int randPoisonousEnemyCount = Random.Range(7, 11);

        List<GameObject> availablePoints = spawnpoints;

        for (int i = 0; i < randShootingEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[6], selectedPoint.transform.position, enemyPrefabs[6].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randSummonerEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[4], selectedPoint.transform.position, enemyPrefabs[4].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        availablePoints = spawnpoints;

        for (int i = 0; i < randPoisonousEnemyCount; i++)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);

            GameObject selectedPoint = availablePoints[randomIndex];

            Instantiate(enemyPrefabs[3], selectedPoint.transform.position, enemyPrefabs[3].transform.rotation);

            availablePoints.RemoveAt(randomIndex);
        }

        StartCoroutine(WaveSixMapThreeSpawnCooldown());
    }

    public IEnumerator WaveSixMapThreeSpawnCooldown()
    {
        yield return new WaitForSeconds(waveSixSpawnCooldown);
        WaveMapThreeManager();
    }

    #endregion
}
