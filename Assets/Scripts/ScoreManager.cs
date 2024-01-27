using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public float worldSpeed = 30f;
    private float speedIncrement = 0.01f;
    
    private void Update() {
        worldSpeed += speedIncrement;
    }
    
    public int highScore;
    private void Awake()
    {
        LoadScore();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [System.Serializable]
    private class SaveData
    {
        public int highScore;
    }

    public void SaveHighScore()
    {
        // create an instance of savedata class
        SaveData saveData = new SaveData();

        // assign highscore
        saveData.highScore = highScore;

        // convert the instance into json
        string json = JsonUtility.ToJson(saveData);

        string path = Application.dataPath + "/savefile.json";

        // write string into a file
        File.WriteAllText( path, json );

    }

    public void LoadScore()
    {
        string path = Application.dataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            highScore = saveData.highScore;
        }
    }
}
