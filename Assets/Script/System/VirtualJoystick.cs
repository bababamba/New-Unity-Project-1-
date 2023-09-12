using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼 수 있는 기능을 지원


public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public GameObject player;
    Player playerScript;
    public float speed;
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;
    [SerializeField] private Image Joy;
    [SerializeField] private Image Stick;
    [SerializeField, Range(10f, 150f)]
    private float leverRange;

    [SerializeField] private Color parency;//투명
    [SerializeField] private Color lucent;//반투명
    [SerializeField] private Color opacity;//불투명
    private Vector2 inputVector;
    private bool isInput;

    

 
    private void Awake()
    {

    }
    private void Start()
    {

        playerScript = player.GetComponent<Player>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
        StartControlJoystick(eventData);
        
        ControlJoystickLever(eventData);
        
        isInput = true;
       
    }
    void Update()
    {
        if (isInput)
        {
            InputControlVector();
        }
    }
    // 오브젝트를 클릭해서 드래그 하는 도중에 들어오는 이벤트 
    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        playerScript.AN.SetBool("walk", true);
        
    }

    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        var clampedDir = inputDir.magnitude < leverRange ? inputDir
            : inputDir.normalized * leverRange;
        lever.anchoredPosition = clampedDir;
        inputVector = clampedDir / leverRange;
    }

    public void StartControlJoystick(PointerEventData eventData)
    {
        parency.a = 255;
        Joy.color = lucent; 
        Stick.color = parency;
        this.GetComponent<RectTransform>().anchoredPosition = eventData.position;
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        parency.a = 0;
        Joy.color = parency;
        Stick.color = parency;
        isInput = false;
        lever.anchoredPosition = Vector2.zero;
        playerScript.AN.SetBool("walk", false);
    }
    
    private void InputControlVector()
    {
        
        
        player.transform.Translate(inputVector * speed * Time.deltaTime);
        playerScript.playerDirection = inputVector;
        
        
    }

}