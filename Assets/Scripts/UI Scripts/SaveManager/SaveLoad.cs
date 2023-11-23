using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Pool;

public class SaveLoad : MonoBehaviour
{
    private static string fileName = "saveData.txt";
    private static string directoryName = "SaveData";
    public static void SaveState(SaveObject so)
    {
        if (!DirectoryExists())
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directoryName);
         
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetSavePath());
        bf.Serialize(file, so);
        file.Close();
    }

    public static SaveObject LoadState()
    {
        SaveObject so = new SaveObject();

        if(SaveExists())
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(GetSavePath(), FileMode.Open);
                so = (SaveObject)bf.Deserialize(file);
                file.Close();
            }
            catch(SerializationException)
            {
                Debug.LogWarning("Failed to load save");
            }
        }
        else
        {
            so = GetDefaultSave();
        }
        return so;

    }

    private static SaveObject GetDefaultSave()
    {
        SaveObject so = new SaveObject();

        so.cameraSlider = 300;
        so.cameraInvert = false;

        return so;
    }

    private static bool SaveExists()
    {
        return File.Exists(GetSavePath());
    }

    private static bool DirectoryExists()
    {
        return Directory.Exists(Application.persistentDataPath + "/" + directoryName);
    }

    private static string GetSavePath()
    {
        return Application.persistentDataPath + "/" + directoryName + "/" + fileName;
    }

}
