using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler Instance;
    public string currentPlayerName;
    public int currentHighScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public int highScore;
    }
    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.playerName = currentPlayerName;
        data.highScore = currentHighScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            currentPlayerName = data.playerName;
            currentHighScore = data.highScore;
        }
    }
}
