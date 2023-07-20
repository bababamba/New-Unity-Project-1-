using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public GameObject gameManager;

    public Slider expSlider; // 게이지 바를 나타내는 Slider 컴포넌트
    public TextMeshProUGUI expPercent;

    public TextMeshProUGUI goldUI;

    public GameObject pauseMenu;
    public Button resumeButton;
    public Button optionButton;
    public Button mainMenuButton;
    private bool isPaused = false;

    public GameObject levelUpMenu;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    

    GameManager gameManagerScript;
    private float gold;
    private float exp; // 플레이어의 현재 경험치
    private float maxExp; // 플레이어의 최대 경험치
    private float expPercentNumber;

    public GameObject inventory;
    public Image invenFrame0;
    public Image invenIcon0;
    public Image invenFrame1;
    public Image invenIcon1;
    public Image invenFrame2;
    public Image invenIcon2;
    public Image invenFrame3;
    public Image invenIcon3;
    public Image invenFrame4;
    public Image invenIcon4;
    public Image invenFrame5;
    public Image invenIcon5;
    public Image invenFrame6;
    public Image invenIcon6;
    public Image invenFrame7;
    public Image invenIcon7;
    public Image invenFrame8;
    public Image invenIcon8;
    public Image invenFrameCurrent;
    public Image invenIconCurrent;


    public Sprite[] itemSprites;
    private int[] currentSpriteIndexOfInven = new int[10];
    void Start()
    {
        // 플레이어 오브젝트에서 ExpController 스크립트를 찾아서 exp와 maxExp 값을 가져옵니다.
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript != null)
        {
            gold = gameManagerScript.goldEarned;
            exp = gameManagerScript.exp;
            maxExp = gameManagerScript.maxExp;
            expPercentNumber = exp / maxExp * 100f;
            expPercent.text = expPercentNumber.ToString() + "%";
        }
        // 버튼 클릭 시 함수를 연결합니다.
        resumeButton.onClick.AddListener(ResumeGame);
        optionButton.onClick.AddListener(OpenOptions);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        Button1.onClick.AddListener(OnLevelUpButton1Click);
        Button2.onClick.AddListener(OnLevelUpButton2Click);
        Button3.onClick.AddListener(OnLevelUpButton3Click);
        // 시작 시에는 pauseMenu를 비활성화합니다.
        pauseMenu.SetActive(false);
        levelUpMenu.SetActive(false);
    }

    void Update()
    {
        exp = gameManagerScript.exp;
        maxExp = gameManagerScript.maxExp;
        expPercentNumber = exp / maxExp * 100f;
        goldUI.text = gold.ToString();
        // 현재 경험치(exp)와 최대 경험치(maxExp) 값을 기반으로 게이지 바의 값을 업데이트합니다.
        if (expSlider != null)
        {
            expSlider.value = exp / maxExp;
            expPercentNumber = (int)expPercentNumber;
            expPercent.text = expPercentNumber.ToString() + "%";
        }
        if (Input.GetKeyDown(KeyCode.P)) // 또는 원하는 키를 사용합니다.
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                ResumeGame();
            }
            else
            {
                pauseMenu.SetActive(true);
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenOptions()
    {
        // 옵션창을 열거나 추가적인 기능을 수행합니다.
        Debug.Log("Options menu opened.");
    }

    public void ReturnToMainMenu()
    {
        // 메인메뉴로 돌아가거나 추가적인 기능을 수행합니다.
        Debug.Log("Returning to main menu.");
    }
    public int chooseNumber(int a)
    {
        return a;
    }
    // 레벨업 버튼을 누를 때 실행될 함수들입니다.
    public void OnLevelUpButton1Click()
    {
        gameManagerScript.levelUp(1);

        ResumeGame();
        levelUpMenu.SetActive(false);
    }

    public void OnLevelUpButton2Click()
    {
        gameManagerScript.levelUp(2);
        ResumeGame();
        levelUpMenu.SetActive(false);
    }

    public void OnLevelUpButton3Click()
    {
        gameManagerScript.levelUp(3);

        ResumeGame();
        levelUpMenu.SetActive(false);
    }

    public void LevelUpStart()
    {
        levelUpMenu.SetActive(true);
        PauseGame();
        
    }
    public void LevelUp(int level)
    {
        levelUpMenu.SetActive(false);
        PauseGame();
        // 레벨업 함수에서 반환된 레벨을 출력합니다.
        Debug.Log("Player Level Up to: " + level);

        // 레벨업 이벤트를 발생시킵니다.

    }
}