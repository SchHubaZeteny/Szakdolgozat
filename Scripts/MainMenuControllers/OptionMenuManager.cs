using UnityEngine;
using System.IO;

public class OptionMenuManager : MonoBehaviour
{
    public GameObject reassureUI;

    public void ClickNewGame()
    {
        reassureUI.SetActive(true);
    }

    public void ClickNo()
    {
        reassureUI.SetActive(false);
    }

    public void ClickYes()
    {
        string path = Path.Combine(Application.persistentDataPath, "savefile.json");

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

}
