using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveGame(Player playerInfo, TPCamera cameraInfo)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/Saves/game.sav";
        FileStream fileStream = new FileStream(savePath, FileMode.Create);
        GameSaveFile gsFile = new GameSaveFile(playerInfo, cameraInfo);

        binaryFormatter.Serialize(fileStream, gsFile);
        fileStream.Close();
    }

    public static GameSaveFile LoadGame()
    {
        string loadPath = Application.persistentDataPath + "/Saves/game.sav";
        if (File.Exists(loadPath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(loadPath, FileMode.Open);
            GameSaveFile gsFile = (GameSaveFile)binaryFormatter.Deserialize(fileStream);
           
            return gsFile;
        }
        else
        {
            return null;
        }
    }
}
