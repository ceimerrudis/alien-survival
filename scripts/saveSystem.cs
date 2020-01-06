using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem
{
    public static void SavePlayer(playerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/user.virus";
        FileStream stream = new FileStream(path, FileMode.Create);

        saveData data = new saveData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static saveData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/user.virus";
        if (File.Exists(path)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            saveData data = formatter.Deserialize(stream) as saveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("error 404 " + path);
            return null;
        }
    }
}
