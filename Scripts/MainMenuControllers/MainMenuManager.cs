using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;
    public GameObject chooseMenuUI;
    public GameObject mapMenuUI;
    public GameObject shopMenuUI;
    public GameObject questsMenuUI;
    public GameObject inventoryMenuUI;

    public AudioClip buttonClickSound;

    private void Start()
    {
        MainManager.Instance.usingLifestealTonic = false;
        MainManager.Instance.usingExplodeTonic = false;
        MainManager.Instance.usingGoldHealTonic = false;
        MainManager.Instance.usingGoldDropTonic = false;
    }

    public void FromMainMenuToChooseMenu()
    {
        mainMenuUI.SetActive(false);
        chooseMenuUI.SetActive(true);
    }

    public void FromMainMenuToOptionsMenu()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void FromChooseMenuToMapMenu()
    {
        chooseMenuUI.SetActive(false);
        mapMenuUI.SetActive(true);
    }

    public void FromChooseMenuToShopMenu()
    {
        chooseMenuUI.SetActive(false);
        shopMenuUI.SetActive(true);
    }

    public void FromChooseMenuToMainMenu()
    {
        chooseMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void FromChooseMenuToQuestsMenu()
    {
        chooseMenuUI.SetActive(false);
        questsMenuUI.SetActive(true);
    }

    public void FromQuestsMenuToChooseMenu()
    {
        questsMenuUI.SetActive(false);
        chooseMenuUI.SetActive(true);
    }

    public void FromMapMenuToChooseMenu()
    {
        mapMenuUI.SetActive(false);
        chooseMenuUI.SetActive(true);
    }

    public void FromChooseMenuToInvetoryMenu()
    {
        chooseMenuUI.SetActive(false);
        inventoryMenuUI.SetActive(true);
    }

    public void FromInvetoryMenuToChooseMenu()
    {
        inventoryMenuUI.SetActive(false);
        chooseMenuUI.SetActive(true);
    }

    public void FromShopMenuToChooseMenu()
    {
        shopMenuUI.SetActive(false);
        chooseMenuUI.SetActive(true);
    }

    public void FromOptionsMenuToMainMenu()
    {
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void ButtonClickSoundPlay()
    {
        SoundFXManager.instance.PlaySoundFXClip(buttonClickSound, 0f, buttonClickSound.length, transform, 1f);
    }
}
