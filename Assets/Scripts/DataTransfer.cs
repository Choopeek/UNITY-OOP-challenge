using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System;
using System.IO;

public class DataTransfer : MonoBehaviour
{
    public static DataTransfer Instance;
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

    
    public string playerName;
    public int bestScore;
    public string playerNameBest;
    [System.Serializable]
    class SaveData
    {
        public string playerNameSaved;
        public int bestScoreSaved;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerNameSaved = playerNameBest;
        data.bestScoreSaved = bestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "./savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameBest = data.playerNameSaved;
            bestScore = data.bestScoreSaved;
        }
    }
    






}
