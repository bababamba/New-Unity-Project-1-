using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager Instance;
    [SerializeField] GameObject OptionPopUp;
    float BGMVolume = 0.8f;
    float SFXVolume = 0.8f;
    public Slider bgmSlider;
    public Slider sfxSlider;
    void Awake()
    {

        DontDestroyOnLoad(gameObject);
        if(Instance == null)
            Instance = this; 
        else if(Instance != this)
            Destroy(this.gameObject);
    }
    private void Start()
    {
        if (bgmSlider != null)
            bgmSlider.value = BGMVolume;
        if (sfxSlider != null)
            sfxSlider.value = SFXVolume;
    }

    void Update()
    {
        
            SetBGMVolume(bgmSlider.value);
            SetSFXVolume(sfxSlider.value);
        
        if (SceneManager.GetActiveScene().name != "maingame" && bgmSource.isPlaying)
            BGM_OFF();
    }

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    

    public AudioClip Title;
    public AudioClip test1;
    //Audio_Manager.Instance.BGM_Title();
    //Audio_Manager.Instance.SFX_ButtonClick();
    public void OptionPopUpOn()
    {
        OptionPopUp.SetActive(true);
    }
    public void OptionPopUpOff()
    {
        OptionPopUp.SetActive(false);
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        BGMVolume = volume;
        Debug.Log(bgmSlider.value);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        SFXVolume = volume;
    }
    public void BGM_Title()
    {
        bgmSource.clip = Title;
        bgmSource.Play();
    }
    public void BGM_OFF()
    {
        bgmSource.Stop();
    }
    public void SFX_Click()
    {
        sfxSource.PlayOneShot(test1);
    }
    public void FindSlider()
    {
        Debug.Log(GameObject.Find("BGM"));
        bgmSlider = GameObject.Find("BGM").GetComponent<Slider>();
        sfxSlider = GameObject.Find("SFX").GetComponent<Slider>();
    }
    public void CloseSettings()
    {
        if (SceneManager.GetActiveScene().name == "IngameMapScreen")
            MapUIManager.manager.CloseUI(3);
        else if (SceneManager.GetActiveScene().name == "maingame")
        {
            OptionPopUp.transform.position = new Vector2(2000, 2000);
        }
    }
}
