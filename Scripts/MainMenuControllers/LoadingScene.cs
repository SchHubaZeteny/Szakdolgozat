using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBarFill;
    public Image backgroundImage;

    public Sprite[] mapSprites;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));

        if (mapSprites != null && sceneId - 1 < mapSprites.Length)
        {
            backgroundImage.sprite = mapSprites[sceneId - 1];
        }
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        operation.allowSceneActivation = false; 

        loadingScreen.SetActive(true);

        float targetProgress = 0f;
        float fillSpeed = 2f;

        while (!operation.isDone)
        {
            targetProgress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBarFill.fillAmount = Mathf.MoveTowards(loadingBarFill.fillAmount, targetProgress, fillSpeed * Time.deltaTime);

            if (loadingBarFill.fillAmount >= 0.99f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
