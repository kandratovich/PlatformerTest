using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void PlayPressed()
    {
        Time.timeScale = 1;
        CharacterStats.lives = 3;
        SceneManager.LoadScene("Level_1");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void MenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_2");
    }
}
