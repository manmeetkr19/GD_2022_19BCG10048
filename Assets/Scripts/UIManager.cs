using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void ScoreUpdate(int score)
    {
        text.text = score + "";
    }
}
