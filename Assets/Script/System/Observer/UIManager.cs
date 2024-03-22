using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private levelUpUI levelUpUIScript;
    [SerializeField]
    private itemManager itemManagerScript;

    public item_base testItem;

    GameManager gameManagerScript;
    private float gold;
    private float exp; // 플레이어의 현재 경험치
    private float maxExp; // 플레이어의 최대 경험치
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
            // 플레이어 오브젝트에서 ExpController 스크립트를 찾아서 exp와 maxExp 값을 가져옵니다.
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
        // 버튼 클릭 시 함수를 연결합니다.
        resumeButton.onClick.AddListener(ResumeGame);
        optionButton.onClick.AddListener(OpenOptions);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);

        // 시작 시에는 pauseMenu를 비활성화합니다.
        
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
        if (Input.GetKeyDown(KeyCode.I)) // 또는 원하는 키를 사용합니다.
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
        if (Input.GetKeyDown(KeyCode.A)) // 또는 원하는 키를 사용합니다.
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
        // 옵션창을 열거나 추가적인 기능을 수행합니다.
        Debug.Log("Options menu opened.");
    }

    public void ReturnToMainMenu()
    {
        // 메인메뉴로 돌아가거나 추가적인 기능을 수행합니다.
        Debug.Log("Returning to main menu.");
        SceneManager.LoadScene("Scenes/mainmenu");
    }
    public int chooseNumber(int a)
    {
        return a;
    }

    // 레벨업 버튼을 누를 때 실행될 함수들입니다.
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
        // 레벨업 함수에서 반환된 레벨을 출력합니다.
        Debug.Log("Player Level Up!");

        // 레벨업 이벤트를 발생시킵니다.

    }
}