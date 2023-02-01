using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySerializer
{
    public static void Serialize(string path, object data)
    {
        using (FileStream stream  = new FileStream(path, FileMode.OpenOrCreate))
        {
            BinaryFormatter binaryFormatter= new BinaryFormatter();
            binaryFormatter.Serialize(stream, data);
        }
    }

    public static T Deserialize<T>(string path) 
    {
        using(FileStream stream = new FileStream(path, FileMode.Open))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            T data = (T) binaryFormatter.Deserialize(stream);

            return data;
        }
    }
}
