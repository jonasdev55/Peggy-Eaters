using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public TMP_Dropdown Resolutions;
    public TMP_Dropdown WindowDropdown;
    public TMP_Dropdown QualityDropdown;
    public TMP_Dropdown MusicDropdown;
    public TMP_Dropdown EffectsDropdown;

    public AudioMixer MusicMixer;
    public AudioMixer EffectsMixer;

    bool fullscreen = true;

    int resolutionIndex;
    int WindowedIndex;
    int QualityIndex;
    int MusicIndex;
    int EffectIndex;

    private void Start()
    {
        resolutionIndex = PlayerPrefs.GetInt("LastRes");
        WindowedIndex = PlayerPrefs.GetInt("LastWin");
        QualityIndex = PlayerPrefs.GetInt("LastQwl");
        MusicIndex = PlayerPrefs.GetInt("Music");
        EffectIndex = PlayerPrefs.GetInt("Effects");

        SetWMode(WindowedIndex);
        SetResolution(resolutionIndex);
        SetQuality(QualityIndex);
        SetMusic(MusicIndex);
        SetEffects(EffectIndex);
    }

    public void SetResolution(int value)
    {
        switch (value)
        {
            case 0:
                Screen.SetResolution(426, 240, fullscreen);
                break;
            case 1:
                Screen.SetResolution(640, 360, fullscreen);
                break;
            case 2:
                Screen.SetResolution(852, 480, fullscreen);
                break;
            case 3:
                Screen.SetResolution(852, 480, fullscreen);
                break;
            case 4:
                Screen.SetResolution(1278, 720, fullscreen);
                break;
            case 5:
                Screen.SetResolution(1920, 1080, fullscreen);
                break;
            case 6:
                Screen.SetResolution(2560, 1440, fullscreen);
                break;
            case 7:
                Screen.SetResolution(3834, 2160, fullscreen);
                break;
        }

        Resolutions.value = value;
        PlayerPrefs.SetInt("LastRes", value);
    }

    public void SetWMode(int value)
    {
        switch (value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                fullscreen = true;
                break;

            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                fullscreen = false;
                break;
        }

        WindowDropdown.value = value;
        PlayerPrefs.SetInt("LastWin", value);
    }

    public void SetQuality(int value)
    {
        QualitySettings.SetQualityLevel(value);
        PlayerPrefs.SetInt("LastQwl", value);
        QualityDropdown.value = value;
    }

    public void SetMusic(int value)
    {
        MusicMixer.SetFloat("MusicVolume", value + value * 10 - value - 80);
        PlayerPrefs.SetInt("Music", value);
        MusicDropdown.value = value;
    }

    public void SetEffects(int value)
    {
        EffectsMixer.SetFloat("EffectsVolume", value + value * 10 - value - 80);
        PlayerPrefs.SetInt("Effects", value);
        EffectsDropdown.value = value;
    }

    public void left(string wich)
    {
        if(wich == "Resolution")
        {
            if(resolutionIndex != 0) resolutionIndex--;
            else resolutionIndex = 6;
            SetResolution(resolutionIndex);
        }

        else if(wich == "WindowMode")
        {
            if (WindowedIndex != 0) WindowedIndex--;
            else WindowedIndex = 1;
            SetWMode(WindowedIndex);
        }

        else if(wich == "Quality")
        {
            if (QualityIndex != 0) QualityIndex--;
            else QualityIndex = 3;
            SetQuality(QualityIndex);
        }

        else if(wich == "Music")
        {
            if (MusicIndex != 0) MusicIndex--;
            else MusicIndex = 10;
            SetMusic(MusicIndex);
        }

        else if(wich == "Effects")
        {
            if (EffectIndex != 0) EffectIndex--;
            else EffectIndex = 10;
            SetEffects(EffectIndex);
        }
    }
    
    public void Right(string wich)
    {
        if (wich == "Resolution")
        {
            if (resolutionIndex != 6) resolutionIndex++;
            else resolutionIndex = 0;
            SetResolution(resolutionIndex);
        }

        else if (wich == "WindowMode")
        {
            if (WindowedIndex != 1) WindowedIndex++;
            else WindowedIndex = 0;
            SetWMode(WindowedIndex);
        }

        else if (wich == "Quality")
        {
            if (QualityIndex != 3) QualityIndex++;
            else QualityIndex = 0;
            SetQuality(QualityIndex);
        }

        else if (wich == "Music")
        {
            if (MusicIndex != 10) MusicIndex++;
            else MusicIndex = 0;
            SetMusic(MusicIndex);
        }

        else if (wich == "Effects")
        {
            if (EffectIndex != 10) EffectIndex++;
            else EffectIndex = 0;
            SetEffects(EffectIndex);
        }
    }
}
