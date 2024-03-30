using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public void SFX_Click()
    {
        sfxSource.PlayOneShot(test1);
    }

}
