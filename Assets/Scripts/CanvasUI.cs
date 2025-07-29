using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class CanvasUI : MonoBehaviour
{
    public InputField inputField;
    public Text highScoreText;
    void Start()
    {
        DataHandler.Instance.LoadData();
        inputField.text = DataHandler.Instance.currentPlayerName;
        highScoreText.text = "HighScore: " + DataHandler.Instance.currentHighScore.ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        DataHandler.Instance.SaveData();
    }
    public void SetName(string nameText)
    {
        DataHandler.Instance.currentPlayerName = nameText;
    }
    public void Exit()
    {
        DataHandler.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
