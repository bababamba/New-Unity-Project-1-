using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ToMain()
    {
        PlayerData.data.CreatePlayerData(100, 100, 10, 999, true);
        SceneManager.LoadScene("Scenes/Main Screen");
    }

    public void OpenSettings()
    {
        MapUIManager.manager.OpenUI(3);
    }

    public void Resume()
    {
        MapUIManager.manager.CloseUI(2);
    }

}
