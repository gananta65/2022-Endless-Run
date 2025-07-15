using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject ScorePanel;
    public static GameManager MyInstance;
    public int score = 0;
    public TextMeshProUGUI[] scoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        ScorePanel.SetActive(true);
        //get text object from ScorePanel and set its text to the current score
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (TextMeshProUGUI text in scoreText)
        {
            text.text = "Score: " + score;
        }
    }
    void Awake()
    {
        MyInstance = this;
    }

    public void ResetLevel()
    {
        GameOverPanel.SetActive(false);
        ScorePanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
