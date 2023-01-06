using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{

    public static void SavePlayer(GameControl player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData playerData = new PlayerData(player);

        formatter.Serialize(stream, playerData);
        stream.Close();

    }


    public static void SaveGuns(GameControl player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/guns.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GunsData playerData = new GunsData(player);

        formatter.Serialize(stream, playerData);
        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return playerData;
        }
        else
        {
            Debug.Log("File location not found");
            return null;
        }
    }

    public static GunsData LoadGun()
    {
        string path = Application.persistentDataPath + "/guns.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GunsData playerData = formatter.Deserialize(stream) as GunsData;
            stream.Close();

            return playerData;
        }
        else
        {
            Debug.Log("File location not found");
            return null;
        }
    }

}
