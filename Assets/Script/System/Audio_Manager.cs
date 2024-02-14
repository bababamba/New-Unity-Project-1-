using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager Instance;

    void Awake()
    {

        DontDestroyOnLoad(gameObject);
        if(Instance == null)
            Instance = this;

        if(bgmSlider != null)
            bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.8f);
        if(sfxSlider != null)
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.8f);
    }

    void Update()
    {
        SetBGMVolume(bgmSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public Slider bgmSlider;
    public Slider sfxSlider;

    public AudioClip Title;
    public AudioClip test1;
    //Audio_Manager.Instance.BGM_Title();
    //Audio_Manager.Instance.SFX_ButtonClick();


    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void BGM_Title()
    {
        bgmSource.clip = Title;
        bgmSource.Play();
    }
    public void SFX_ClickBucket()
    {
        sfxSource.PlayOneShot(test1);
    }

}
