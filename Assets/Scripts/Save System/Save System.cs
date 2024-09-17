using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save_System
{
        public static void SavePlayer(PlayerController player)
        {
            BinaryFormatter formatter = new BinaryFormatter(); // BinaryFormatter is used to serialize and deserialize data
            string path = Application.persistentDataPath + "/player.save"; // Application.persistentDataPath is used to store data in the game, and the path is the path to the save file
            FileStream stream = new FileStream(path, FileMode.Create); // FileStream is used to open the file, and FileMode.Create is used to create the file
            
            PlayerData data = new PlayerData(player); // PlayerData is the data that is being saved
            
            formatter.Serialize(stream, data); // Serialize the data, and write it to the file
            stream.Close(); // Close the file
            
            Debug.Log("Player saved at " + path);
        }
        
        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.save"; // Application.persistentDataPath is used to store data in the game, and the path is the path to the save file
            if (File.Exists(path)) // Check if the file exists
            {
                BinaryFormatter formatter = new BinaryFormatter(); // BinaryFormatter is used to serialize and deserialize data
                FileStream stream = new FileStream(path, FileMode.Open); // FileStream is used to open the file, and FileMode.Open is used to open the file
                
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                
                return data;
                
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
}
