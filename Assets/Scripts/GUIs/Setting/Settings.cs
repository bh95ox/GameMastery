using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Managers;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private GameObject Setting_Panel;
    [SerializeField] private GameObject MainMenu_Panel;
    [SerializeField] private Slider MasterVol;
    [SerializeField] private Slider MusicVol;

    private SettingManager settingManager;
    private GameManager gameManager;

    Resolution[] resolutions;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GameObject GetSettingManager = GameObject.FindWithTag("SettingManager");
        if (GetSettingManager != null) { settingManager = GetSettingManager.GetComponent<SettingManager>(); }
        else{gameManager.NeedManager("SettingManager");}

        // Get the screen Resolutions
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int CurrentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }
        // Get the screen Resolutions Add the screen Resolution to dropDown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = CurrentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    private void Update()
    {
        MasterVol.value = settingManager.MasterAux;
        MusicVol.value = settingManager.MusicAux;

    }

    public void SaveSettings()
    {
        Debug.Log("Saving In Progress");
        settingManager.SaveSetting();
        Setting_Panel.SetActive(false);
        MainMenu_Panel.SetActive(true);
    }

    // GamePlay Setting 
    public void SetQuality(int Index)
    {
        QualitySettings.SetQualityLevel(Index);
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Fullscreen(bool isFullscreen)
    {
        settingManager.Fullscreen= isFullscreen;
    }

    public void MasterAux(float Vol)
    {
        settingManager.MasterAux = Vol;
    }

    public void MusicAux(float Vol)
    {
        settingManager.MusicAux = Vol;
    }

    // General Setting

    public void MouseSenX(float SenX)
    {
        settingManager.Mouse_SenX = SenX;
    }

    public void SoundFXAux(float Vol)
    {
        settingManager.SoundFXAux = Vol;
    }

    public void UIAux(float Vol)
    {
        settingManager.UIFXAux = Vol;
    }

    public void AntiAliasing(int Index)
    {
        QualitySettings.antiAliasing = Index;
    }

    public void Mute(bool isMute)
    {
        settingManager.Mute = isMute;
    }

    public void Vsync(bool SyncOn)
    {
        settingManager.VSync = SyncOn;
    }

    
}
