using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public void StartGame()
    {
        // Ư�� ������ �̵�
        SceneManager.LoadScene("Scenes/IngameMapScreen");
    }

    public void OpenSettings()
    {
        Audio_Manager.Instance.OptionPopUpOn();
    }

    public void QuitGame()
    {
        // ���� ����
        Application.Quit();
    }
}
