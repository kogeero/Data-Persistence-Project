using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainestManager : MonoBehaviour
{
    public static MainestManager Instance;

    public int m_HighScore = 0;
    public string highScoreName = "Name";
    public string currentName = "Name";

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    public class SaveData
    {
        public string name;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = m_HighScore;
        data.name = currentName;
        highScoreName = currentName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            m_HighScore = data.highScore;
            highScoreName = data.name;
        }
    }

}
