using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu_UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        // Ư�� ������ �̵�
        SceneManager.LoadScene("Scenes/maingame");
    }

    public void QuitGame()
    {
        // ���� ����
        Application.Quit();
    }
}

