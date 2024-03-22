using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private levelUpUI levelUpUIScript;
    [SerializeField]
    private itemManager itemManagerScript;

    public item_base testItem;

    GameManager gameManagerScript;
    private float gold;
    private float exp; // �÷��̾��� ���� ����ġ
    private float maxExp; // �÷��̾��� �ִ� ����ġ
    private float expPercentNumber;

    public GameObject inventoryObject;
    private inventory inventory;


    private void Awake()
    {
        inventoryObject.SetActive(true);
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "maingame")
        {
            // �÷��̾� ������Ʈ���� ExpController ��ũ��Ʈ�� ã�Ƽ� exp�� maxExp ���� �����ɴϴ�.
            gameManagerScript = gameManager.GetComponent<GameManager>();
            inventory = inventoryObject.GetComponent<inventory>();
            if (gameManagerScript != null)
            {
                gold = gameManagerScript.goldEarned;
                exp = gameManagerScript.exp;
                maxExp = gameManagerScript.maxExp;
                expPercentNumber = exp / maxExp * 100f;
                expPercent.text = expPercentNumber.ToString() + "%";
            }
        }
        // ��ư Ŭ�� �� �Լ��� �����մϴ�.
        resumeButton.onClick.AddListener(ResumeGame);
        optionButton.onClick.AddListener(OpenOptions);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);

        // ���� �ÿ��� pauseMenu�� ��Ȱ��ȭ�մϴ�.
        
        pauseMenu.SetActive(false);

        inventoryObject.SetActive(true);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "maingame")
        {
            exp = gameManagerScript.exp;
            maxExp = gameManagerScript.maxExp;
            expPercentNumber = exp / maxExp * 100f;
            goldUI.text = gold.ToString();
        }
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
                inventoryObject.SetActive(false);
                pauseMenu.SetActive(false);
                ResumeGame();
            }
            else
            {
                pauseMenu.SetActive(true);
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.I)) // �Ǵ� ���ϴ� Ű�� ����մϴ�.
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                inventoryObject.SetActive(false);
                ResumeGame();
            }
            else
            {
                inventoryObject.SetActive(true);
                PauseGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) // �Ǵ� ���ϴ� Ű�� ����մϴ�.
        {
            inventory.AcquireItem(testItem);
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
        SceneManager.LoadScene("Scenes/mainmenu");
    }
    public int chooseNumber(int a)
    {
        return a;
    }

    // ������ ��ư�� ���� �� ����� �Լ����Դϴ�.
    public void LevelUpStart()
    {
        if (SceneManager.GetActiveScene().name == "maingame")
        {
            List<item_base> item_selected = itemManagerScript.forLevelUP();

            levelUpUIScript.OpenLevelUP();

            levelUpUIScript.setItems(item_selected[0], item_selected[1], item_selected[2]);
            PauseGame();
        }
        
    }
    public void LevelUp()
    {
        ResumeGame();
        // ������ �Լ����� ��ȯ�� ������ ����մϴ�.
        Debug.Log("Player Level Up!");

        // ������ �̺�Ʈ�� �߻���ŵ�ϴ�.

    }
}