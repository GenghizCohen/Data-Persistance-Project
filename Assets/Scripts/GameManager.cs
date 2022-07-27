using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public string currentPlayerName;
    public int currentTotalScore;
    public string highScorePlayerName;
    public int highScoreTotalScore;
    public GameObject mainManager;




    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        mainManager = GameObject.Find("MainManager");
        LoadHighScore();

    }


    public void UpdateCurrentPlayerName(string name)
    {
        currentPlayerName = name;
        Debug.Log(currentPlayerName + currentTotalScore);
    }

    public void UpdateCurrentTotalScore(int score)
    {
        currentTotalScore = score;
        Debug.Log(currentPlayerName + currentTotalScore);
        if (currentTotalScore >= highScoreTotalScore)
        {
            UpdateHighScore();
        }
    }

    public void UpdateHighScore()
    {
        highScorePlayerName = currentPlayerName;
        highScoreTotalScore = currentTotalScore;
        SaveHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScoreTotalScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScorePlayerName = highScorePlayerName;
        data.highScoreTotalScore = highScoreTotalScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highScorePlayerName;
            highScoreTotalScore = data.highScoreTotalScore;
        }
    }

}
