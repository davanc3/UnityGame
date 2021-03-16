using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartPress : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
    public void HomePressed()
    {
        SceneManager.LoadScene("Menu");
    }
}
