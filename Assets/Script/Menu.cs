using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject ButtonStart;
    public GameObject ButtonQuit;

    public void OnClickPlay()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
