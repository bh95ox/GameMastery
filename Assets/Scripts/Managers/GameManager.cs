using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject InputManager;
        [SerializeField] private GameObject AudioManager;
        [SerializeField] private GameObject SettingManager;
        [SerializeField] private GameObject DataManager;

        public static GameObject _GameManager;

        private GameObject[] GetInputManagers;
        private GameObject[] GetAudioManagers;
        private GameObject[] GetSettingManagers;
        private GameObject[] GetDataManager;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _GameManager = gameObject;

            // Creates Root Directory for the Game save files
            if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
            }

            // Creates a Directory to Store the player's Game Settings
            if (!Directory.Exists(Application.persistentDataPath + "/Setting"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Setting");
            }

            CheckSettingManager();
            CheckAudioManager();
            CheckInputManger();
            CheckDataManager();
        }

        private void CheckSettingManager()
        {
            GetSettingManagers = GameObject.FindGameObjectsWithTag("SettingManager");
            if (GetSettingManagers != null)
            {
                if (GetSettingManagers.Length > 1)
                {
                    foreach (GameObject i in GetSettingManagers)
                    {
                        Destroy(i);
                    }
                    Instantiate(SettingManager);
                }
                else
                {
                    GameObject CurrentSettingM = GetSettingManagers[0];
                    if (CurrentSettingM != null)
                    {
                        Debug.Log("Setting Manager Up and Running");
                    }
                    else
                    {
                        Instantiate(SettingManager);
                        Debug.Log("Setting Manager Up and Running");
                    }
                }
            }
            else
            {
                Instantiate(SettingManager);
            }
        }

        private void CheckInputManger()
        {
            GetInputManagers = GameObject.FindGameObjectsWithTag("InputManager");
            if (GetInputManagers != null)
            {
                if (GetInputManagers.Length > 1)
                {
                    foreach (GameObject i in GetInputManagers)
                    {
                        int amount = GetInputManagers.Length;
                        Debug.Log(amount);
                        Destroy(i);
                    }
                    Instantiate(InputManager);
                }
                else
                {
                    GameObject CurrentInputM = GetInputManagers[0];
                    if (CurrentInputM != null)
                    {
                        Debug.Log("Input Manager Up and Running");
                    }
                    else
                    {
                        Instantiate(InputManager);
                        Debug.Log("Input Manager Up and Running");
                    }
                }
            }
            else
            {
                Instantiate(InputManager);
            }

        }

        private void CheckAudioManager()
        {
            GetAudioManagers = GameObject.FindGameObjectsWithTag("AudioManager");
            if (GetAudioManagers != null)
            {
                if (GetAudioManagers.Length > 1)
                {
                    foreach (GameObject i in GetAudioManagers)
                    {
                        Destroy(i);
                    }
                    Instantiate(AudioManager);
                }
                else
                {
                    GameObject CurrentAudioM = GetAudioManagers[0];
                    if (CurrentAudioM != null)
                    {
                        Debug.Log("Audio Manager Up and Running");
                    }
                    else
                    {
                        Instantiate(AudioManager);
                        Debug.Log("Audio Manager Up and Running");
                    }
                }
            }
            else
            {
                Instantiate(AudioManager);
            }

        }

        private void CheckDataManager()
        {
            GetDataManager = GameObject.FindGameObjectsWithTag("DataManager");
            if (GetDataManager != null)
            {
                if (GetDataManager.Length > 1)
                {
                    foreach (GameObject i in GetDataManager)
                    {
                        Destroy(i);
                    }
                    Instantiate(DataManager);
                }
                else
                {
                    GameObject CurrentDataM = GetDataManager[0];
                    if (CurrentDataM != null)
                    {
                        Debug.Log("Audio Manager Up and Running");
                    }
                    else
                    {
                        Instantiate(DataManager);
                        Debug.Log("Audio Manager Up and Running");
                    }
                }
            }
            else
            {
                Instantiate(DataManager);
            }

        }


        public GameObject NeedManager(string ManagerName)
        {
            if (ManagerName == "SettingManager")
            {
                Instantiate(SettingManager);
                return SettingManager;
            }
            else if (ManagerName == "InputManager")
            {
                Instantiate(InputManager);
                return InputManager;
            }
            else if (ManagerName == "AudioManager")
            {
                Instantiate(AudioManager);
                return AudioManager;
            }
            else if (ManagerName == "DataManager")
            {
                Instantiate(DataManager);
                return DataManager;
            }
            else
            {
                return null;
            }
        }
    }
}

