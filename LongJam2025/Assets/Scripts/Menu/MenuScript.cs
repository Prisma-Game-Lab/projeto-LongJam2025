using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] string scene;

    public void StartGame()
    {
        if (scene == "MainScene")
        {
            AudioManager.Instance.PlayMusic("menu");
        }
        else
        {
            AudioManager.Instance.PlayMusic("game");
        }
        SceneManager.LoadScene(scene);
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
