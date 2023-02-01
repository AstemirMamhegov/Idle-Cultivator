using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scriptes.Save
{
    public class SaveSystem : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string saveFileName;
        [SerializeField] private string pathToSaveFile;
        [SerializeField] public CharacterModel characterData;

        public void Awake()
        {
            characterData = null;
            this.pathToSaveFile = Path.Combine(Application.dataPath, this.saveFileName);
            LoadSave();
        }

        public void LoadSave()
        {
            if (File.Exists(this.pathToSaveFile))
            {
                this.characterData = BinarySerializer.Deserialize<CharacterModel>(this.pathToSaveFile);
            }
        }

        public void Save()
        {
            if (this.characterData != null)
                BinarySerializer.Serialize(this.pathToSaveFile, this.characterData);
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}
