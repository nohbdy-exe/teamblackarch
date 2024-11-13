using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.ComponentModel;

public class FileDataHandler 
{
    private string dataDirPath = "";

    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
    public GameData Load()
    {
        //Path.Combine accounts for different operating systms
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                // load serialized data from file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //deserialize from Json back to GameData Object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e) 
            {
                Debug.LogError("Error occured while trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        

        return loadedData;
    }
    public void Save(GameData data)
    {
        //Path.Combine accounts for different operating systms
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize game data object to json to store
            string dataToStore = JsonUtility.ToJson(data, true);

            // Write serialized data to file system
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured while trying to save data to file: " + fullPath + "\n" + e);
        }
    }
}
