using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName = "MainScene";

    public void ContinueGame()
    {
        SceneManager.LoadScene(sceneName);
    }

}
