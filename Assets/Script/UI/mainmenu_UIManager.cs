using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu_UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        // 특정 씬으로 이동
        SceneManager.LoadScene("Scenes/maingame");
    }

    public void QuitGame()
    {
        // 게임 종료
        Application.Quit();
    }
}

