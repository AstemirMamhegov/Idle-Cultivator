using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad 
{
    public static List<CharacterModel> characterModels= new List<CharacterModel>();

    public static void Save()
    {
        characterModels.Add(CharacterModel.instance);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/characterModels.gd");
        bf.Serialize(file, SaveLoad.characterModels);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/characterModels.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/characterModels.gd", FileMode.Open);
            SaveLoad.characterModels = (List<CharacterModel>)bf.Deserialize(file);
            file.Close();
        }
    }
}
