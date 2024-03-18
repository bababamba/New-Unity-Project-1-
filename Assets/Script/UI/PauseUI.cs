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
        SceneManager.LoadScene("Scenes/Main Screen");
    }
    public void Resume()
    {
        MapUIManager.manager.CloseUI(2);
    }

}
