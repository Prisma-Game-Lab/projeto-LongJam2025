using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        AudioManager.Instance.PlayMusic("game");
        SceneManager.LoadScene("TestScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Click()
    {
        AudioManager.Instance.PlaySFX("click");
    }
}
