using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text FinalScoreText;

    public int floors = 0;
    public int itemLevels = 0;
    public int enemyKills = 0;

    void Start()
    {
        ScoreText = this.transform.Find("ScoreText").GetComponent<TMP_Text>();
        FinalScoreText = this.transform.Find("FinalScoreText").GetComponent<TMP_Text>();

        this.GetComponent<RectTransform>().SetAsFirstSibling();
        //this.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckScore();

        ScoreText.text = "floors : " + floors + "\nitem levels : " + itemLevels + "\nenemy kills : " + enemyKills + "\ngold : " + PlayerData.data.gold;

        FinalScoreText.text = "your score : " + ((floors + itemLevels) * enemyKills + PlayerData.data.gold);
    }

    public void CheckScore()
    {
        floors = PlayerData.data.curFloor;
        itemLevels = 0;
        foreach (weapon_base weapon in PlayerData.data.weapons)
            itemLevels += weapon.level;
        enemyKills = PlayerData.data.killCount;


    }

    public void Close()
    {
        PlayerData.data.CreatePlayerData(100, 100, 10, 999, true);
        SceneManager.LoadScene("Main Screen");
    }

}
