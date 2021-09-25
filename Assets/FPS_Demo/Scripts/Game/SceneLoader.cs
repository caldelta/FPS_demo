using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{    
    private const string MAIN = "MainNewMap";
    private const string INTRO = "IntroMenu";
    private const string LOSE = "LoseScene";
    private const string WIN = "WinScene";

    public void LoadIntro()
    {
        SceneManager.LoadScene(INTRO);
    }
    public void LoadMain()
    {
        SceneManager.LoadScene(MAIN);
    }
    public void LoadLose()
    {
        SceneManager.LoadScene(LOSE);
    }
    public void LoadWin()
    {
        SceneManager.LoadScene(WIN);
    }
}
