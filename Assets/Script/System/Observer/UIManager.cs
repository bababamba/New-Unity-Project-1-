using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public GameObject gameManager;

    public Slider expSlider; // ������ �ٸ� ��Ÿ���� Slider ������Ʈ
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
    private float exp; // �÷��̾��� ���� ����ġ
    private float maxExp; // �÷��̾��� �ִ� ����ġ
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
        // �÷��̾� ������Ʈ���� ExpController ��ũ��Ʈ�� ã�Ƽ� exp�� maxExp ���� �����ɴϴ�.
        gameManagerScript = gameManager.GetComponent<GameManager>();
        if (gameManagerScript != null)
        {
            gold = gameManagerScript.goldEarned;
            exp = gameManagerScript.exp;
            maxExp = gameManagerScript.maxExp;
            expPercentNumber = exp / maxExp * 100f;
            expPercent.text = expPercentNumber.ToString() + "%";
        }
        // ��ư Ŭ�� �� �Լ��� �����մϴ�.
        resumeButton.onClick.AddListener(ResumeGame);
        optionButton.onClick.AddListener(OpenOptions);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        Button1.onClick.AddListener(OnLevelUpButton1Click);
        Button2.onClick.AddListener(OnLevelUpButton2Click);
        Button3.onClick.AddListener(OnLevelUpButton3Click);
        // ���� �ÿ��� pauseMenu�� ��Ȱ��ȭ�մϴ�.
        pauseMenu.SetActive(false);
        levelUpMenu.SetActive(false);
    }

    void Update()
    {
        exp = gameManagerScript.exp;
        maxExp = gameManagerScript.maxExp;
        expPercentNumber = exp / maxExp * 100f;
        goldUI.text = gold.ToString();
        // ���� ����ġ(exp)�� �ִ� ����ġ(maxExp) ���� ������� ������ ���� ���� ������Ʈ�մϴ�.
        if (expSlider != null)
        {
            expSlider.value = exp / maxExp;
            expPercentNumber = (int)expPercentNumber;
            expPercent.text = expPercentNumber.ToString() + "%";
        }
        if (Input.GetKeyDown(KeyCode.P)) // �Ǵ� ���ϴ� Ű�� ����մϴ�.
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
        // �ɼ�â�� ���ų� �߰����� ����� �����մϴ�.
        Debug.Log("Options menu opened.");
    }

    public void ReturnToMainMenu()
    {
        // ���θ޴��� ���ư��ų� �߰����� ����� �����մϴ�.
        Debug.Log("Returning to main menu.");
    }
    public int chooseNumber(int a)
    {
        return a;
    }
    // ������ ��ư�� ���� �� ����� �Լ����Դϴ�.
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
        // ������ �Լ����� ��ȯ�� ������ ����մϴ�.
        Debug.Log("Player Level Up to: " + level);

        // ������ �̺�Ʈ�� �߻���ŵ�ϴ�.

    }
}