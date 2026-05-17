using UnityEngine;

public class MapCompletionManager : MonoBehaviour
{
    public GameObject map1Completion;
    public GameObject map2Completion;
    public GameObject map3Completion;

    public GameObject map2LockedButton;
    public GameObject map3LockedButton;
    public GameObject map2PlayButton;
    public GameObject map3PlayButton;

    void Start()
    {
        setCompleted();
        setPlayable();
    }

    public void setCompleted()
    {
        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.playerMap1Completed)
            {
                map1Completion.SetActive(true);
            }
            if (MainManager.Instance.playerMap2Completed)
            {
                map2Completion.SetActive(true);
            }
            if (MainManager.Instance.playerMap3Completed)
            {
                map3Completion.SetActive(true);
            }
        }
    }

    public void setPlayable()
    {
        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.playerMap1Completed)
            {
                map2LockedButton.SetActive(false);
                map2PlayButton.SetActive(true);
            }
            if (MainManager.Instance.playerMap2Completed)
            {
                map3LockedButton.SetActive(false);
                map3PlayButton.SetActive(true);
            }
        }
    }
}
