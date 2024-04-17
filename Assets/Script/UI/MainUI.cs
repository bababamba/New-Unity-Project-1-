using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public void StartGame()
    {
        // 특정 씬으로 이동
        SceneManager.LoadScene("Scenes/IngameMapScreen");
    }

    public void OpenSettings()
    {
        Audio_Manager.Instance.OptionPopUpOn();
    }

    public void QuitGame()
    {
        // 게임 종료
        Application.Quit();
    }
}
