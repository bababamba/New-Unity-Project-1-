using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public void ToMain()
    {
        // Ư�� ������ �̵�
        SceneManager.LoadScene("Scenes/Main Screen");
    }

    public void Init()
    {
        this.gameObject.SetActive(true);
        this.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

}
