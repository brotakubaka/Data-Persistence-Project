using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    // VARIABLES FOR CURRENT SESSION
    public string playerName;
    public int currentScore;

    // VARIABLES FOR HIGH SCORE SESSION
    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        // destroys copy MainManager is one exists in scene with original
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // if this is the only MainManager, do not destroy
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
        //Do this or the code won't know a high score exists in MainManager
    }

    // data persistence across scenes
    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveHighScore(int currentScore, string playerName)
    {
        //First, create a new instance of the save data
        SaveData data = new SaveData();

        //Then, specify what you want to store
        data.highScore = currentScore;
        data.highScoreName = playerName;

        // Next, transform that instance to JSON with JsonUtility.ToJson;
        string json = JsonUtility.ToJson(data);

        // Finally, use the special method File.WriteAllText to write a string to file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        // Find JSON save data and reassign it to its variable using JsonUtility.FromJson<T>(json);
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // assign highScore and highScoreName its appropriate saved data
            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }
}
