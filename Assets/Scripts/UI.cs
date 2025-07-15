using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnExitButtonClicked()
    {
        Application.Quit();
        Debug.Log("Exit Game"); // Ini hanya terlihat saat dijalankan di Editor
    }

    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Exit Game"); // Ini hanya terlihat saat dijalankan di Editor
    }
}
