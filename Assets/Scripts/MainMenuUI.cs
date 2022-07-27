using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MainMenuUI : MonoBehaviour
    

{
    public string playerName;
    public string highScoreName;
    public string highScore;
    public GameObject inputField;



    public void Awake()
    {
        if (GameManager.gameManager.currentPlayerName == "")
        {
            inputField.GetComponent<TMP_InputField>().text = "PlayerName";
        }
        else
        {
            inputField.GetComponent<TMP_InputField>().text = GameManager.gameManager.currentPlayerName;
        }

    }

    public void StartNew()
    {
        playerName = inputField.GetComponent<TMP_InputField>().text;
        GameManager.gameManager.UpdateCurrentPlayerName(playerName);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
