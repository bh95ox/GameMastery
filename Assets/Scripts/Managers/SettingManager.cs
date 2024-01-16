using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    [System.Serializable]
    public class Loadsettings
    {
        public TMP_Dropdown Setting_Resolution;
        public TMP_Dropdown Setting_Quality;
        public TMP_Dropdown Setting_Anti_Al;
        public float Setting_Mouse_SenX;
        public bool Setting_FullScreen;
        public bool Setting_Mute;
        public bool Setting_VSync;
        public float Setting_MasterAux;
        public float Setting_MusicAux;
        public float Setting_SoundFXAux;
        public float Setting_UIFXAux;
    }

    public class SettingManager : MonoBehaviour
    {
        // General Settings
        private TMP_Dropdown Setting_Resolution;
        private TMP_Dropdown Setting_Quality;
        private TMP_Dropdown Setting_Anti_Al;
        private float Setting_Mouse_SenX;
        private bool Setting_FullScreen;
        private bool Setting_Mute;
        private bool Setting_MotionB;
        private bool Setting_VSync;
        private int Setting_FPSLimiter;
        private float Setting_MasterAux;
        private float Setting_MusicAux;
        private float Setting_SoundFXAux;
        private float Setting_UIFXAux;

        public TMP_Dropdown Resolution { get { return Setting_Resolution; } set { Setting_Resolution = value; } }
        public TMP_Dropdown Quality { get { return Setting_Quality; } set { Setting_Quality = value; } }
        public TMP_Dropdown Anti_Al { get { return Setting_Anti_Al; } set { Setting_Anti_Al = value; } }
        public float Mouse_SenX { get { return Setting_Mouse_SenX; } set { Setting_Mouse_SenX = value; } }
        public float MasterAux { get { return Setting_MasterAux; } set { Setting_MasterAux = value; } }
        public float MusicAux { get { return Setting_MusicAux; } set { Setting_MusicAux = value; } }
        public float SoundFXAux { get { return Setting_SoundFXAux; } set { Setting_SoundFXAux = value; } }
        public float UIFXAux { get { return Setting_UIFXAux; } set { Setting_UIFXAux = value; } }
        public bool Mute { get { return Setting_Mute; } set { Setting_Mute = value; } }
        public bool Fullscreen { get { return Setting_FullScreen; } set { Setting_FullScreen = value; } }
        public bool MotionB { get { return Setting_MotionB; } set { Setting_MotionB = value; } }
        public bool VSync { get { return Setting_VSync; } set { Setting_VSync = value; } }
        public int FPSLimiter { get { return Setting_FPSLimiter; } set { Setting_FPSLimiter = value; } }

        //All Variables
        private string GameSettings_Path;

        [SerializeField] private string File_Location = "/Setting/GameSetting.Json";// If the file has changed name or folder

        private void Awake()
        {
            DontDestroyOnLoad(this);
            GameSettings_Path = Application.persistentDataPath + File_Location;
            LoadDataOnAwake();
        }

        private void LoadDataOnAwake()
        {
            if (File.Exists(GameSettings_Path))
            {
                Debug.Log("File Found");
                try
                {
                    LodFromJson();
                }
                catch (Exception err)
                {
                    Debug.LogError($"Unable to Load data due to: {err.Message} {err.StackTrace}");
                    return;
                }
            }
            else
            {
                Debug.Log("File Not Found");
                using FileStream Fc = File.Create(GameSettings_Path);
                Fc.Flush();
                Fc.Close();
                ResetSetting();
            }

        }

        public void ResetSetting()
        {
            if (File.Exists("ResetSetting.json"))
            {
                Debug.Log("Resetting User Setting");
                // loads the Data and save it
                string resetFile = "ResetSetting.json";
                string json = File.ReadAllText(resetFile);
                Loadsettings data = JsonUtility.FromJson<Loadsettings>(json);
                this.Setting_Resolution = data.Setting_Resolution;
                this.Setting_Quality = data.Setting_Quality;
                this.Setting_Anti_Al = data.Setting_Anti_Al;
                this.Setting_Mouse_SenX = data.Setting_Mouse_SenX;
                this.Setting_FullScreen = data.Setting_FullScreen;
                this.Setting_Mute = data.Setting_Mute;
                this.Setting_VSync = data.Setting_VSync;
                this.Setting_MasterAux = data.Setting_MasterAux;
                this.Setting_MusicAux = data.Setting_MusicAux;
                this.Setting_SoundFXAux = data.Setting_SoundFXAux;
                this.Setting_UIFXAux = data.Setting_UIFXAux;

                string Writejson = JsonUtility.ToJson(data, true);
                File.WriteAllText(GameSettings_Path, Writejson);
            }
            else
            {
                Debug.LogError("Reset File not Found!");
            }
        }

        public void SaveSetting()
        {
            Loadsettings data = new Loadsettings();
            data.Setting_Resolution = this.Setting_Resolution;
            data.Setting_Quality = this.Setting_Quality;
            data.Setting_Anti_Al = this.Setting_Anti_Al;
            data.Setting_Mouse_SenX = this.Setting_Mouse_SenX;
            data.Setting_FullScreen = this.Setting_FullScreen;
            data.Setting_Mute = this.Setting_Mute;
            data.Setting_VSync = this.Setting_VSync;
            data.Setting_MasterAux = this.Setting_MasterAux;
            data.Setting_MusicAux = this.Setting_MusicAux;
            data.Setting_SoundFXAux = this.Setting_SoundFXAux;
            data.Setting_UIFXAux = this.Setting_UIFXAux;

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(GameSettings_Path, json);
        }

        private void LodFromJson()
        {
            string json = File.ReadAllText(GameSettings_Path);
            Loadsettings data = JsonUtility.FromJson<Loadsettings>(json);
            this.Setting_Resolution = data.Setting_Resolution;
            this.Setting_Quality = data.Setting_Quality;
            this.Setting_Anti_Al = data.Setting_Anti_Al;
            this.Setting_Mouse_SenX = data.Setting_Mouse_SenX;
            this.Setting_FullScreen = data.Setting_FullScreen;
            this.Setting_Mute = data.Setting_Mute;
            this.Setting_VSync = data.Setting_VSync;
            this.Setting_MasterAux = data.Setting_MasterAux;
            this.Setting_MusicAux = data.Setting_MusicAux;
            this.Setting_SoundFXAux = data.Setting_SoundFXAux;
            this.Setting_UIFXAux = data.Setting_UIFXAux;

            Debug.Log("Settings loaded Successfully");
        }

    }
}





