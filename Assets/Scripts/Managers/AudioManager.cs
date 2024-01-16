using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public AudioMixer audioMixer;
        private SettingManager settingManager;

        private void Start()
        {
            DontDestroyOnLoad(this);
            GameObject GetSettingManager = GameObject.FindWithTag("SettingManager");
            if (GetSettingManager != null)
            {
                settingManager = GetSettingManager.GetComponent<SettingManager>();
            }
        }

        private void Update()
        {
            audioMixer.SetFloat("Master", settingManager.MasterAux);
            audioMixer.SetFloat("SoundFX", settingManager.SoundFXAux);
            audioMixer.SetFloat("Music", settingManager.MusicAux);
            audioMixer.SetFloat("UIFX", settingManager.UIFXAux);

        }


    }
}


