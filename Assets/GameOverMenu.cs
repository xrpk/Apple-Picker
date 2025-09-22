using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // needed for TextMeshPro

public class GameOverMenu : MonoBehaviour
{
    public TMP_Text finalScoreText;

    public void Start()
    {
        // Load saved score
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Score: " + finalScore;
    }

    public void PlayAgain()
    {
        // Reload main game scene
        SceneManager.LoadScene("_Scene_0");
    }
}
