using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public UIManager manager;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "maingame")
        {
            manager = GameObject.Find("UIManager").GetComponent<UIManager>();
            manager.setting = GameObject.Find("Setting");
        }
        this.gameObject.SetActive(false);
    }

    public void ToMain()
    {
        PlayerData.data.CreatePlayerData(100, 100, 10, 999, true);
        SceneManager.LoadScene("Scenes/Main Screen");
    }

    public void OpenSettings()
    {
        if(SceneManager.GetActiveScene().name == "IngameMapScreen")
            MapUIManager.manager.OpenUI(3);
        else if (SceneManager.GetActiveScene().name == "maingame")
        {
            manager.setting.SetActive(true);
            manager.setting.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

    }
    public void CloseSettings()
    {
        if (SceneManager.GetActiveScene().name == "IngameMapScreen")
            MapUIManager.manager.CloseUI(3);
        else if (SceneManager.GetActiveScene().name == "maingame")
        {
            manager.setting.SetActive(true);
            manager.setting.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }

    public void Resume()
    {
        if (SceneManager.GetActiveScene().name == "IngameMapScreen")
            MapUIManager.manager.CloseUI(2);
        else if (SceneManager.GetActiveScene().name == "maingame")
        {
            manager.ResumeGame();
            gameObject.SetActive(false);
        }

    }

}
