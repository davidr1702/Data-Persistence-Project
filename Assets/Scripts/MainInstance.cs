using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainInstance : MonoBehaviour
{
    public static MainInstance Instance;
    public string BestScorePlayer;
    public string CurrentPlayer;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }
    
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();

        data.playerName = BestScorePlayer;
        data.bestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScorePlayer = data.playerName;
            BestScore = data.bestScore;
        }
    }
}
