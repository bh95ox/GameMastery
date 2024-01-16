using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Managers
{
    [System.Serializable]
    public class GameDataManager : MonoBehaviour
    {
        public List<GameObject> gameObjects;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void SaveGame(int LocationIndex)
        {
            string FileLocation = Application.persistentDataPath + "/Saves/File" + LocationIndex + ".Json";
            Debug.Log("Saving Data");
            Debug.Log(FileLocation);
        }

        public void LoadGame(int LocationIndex)
        {
            string FileLocation = Application.persistentDataPath + "/Saves/File" + LocationIndex + ".Json";
            Debug.Log("Loading Data");
            Debug.Log(FileLocation);
        }

    }
}

