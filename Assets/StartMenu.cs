using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button startButton; 
    public string sceneToLoad = "_Scene_0";

    void Start()
    {
        // When the button is clicked, call StartGame()
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
