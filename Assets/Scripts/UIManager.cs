using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [NotNull] public Text timeText;
    public float startTime;
    float currentTime;
    float endTime;

    [NotNull] public Text livesText;
    public int playerLives = 0;
    bool isPlayerAlive = true;

    void Start() {
        this.startTime = 20;
        this.playerLives = 3;
    }

    void Update() {
        DisplayTime();
        DisplayLives();
        IsPlayerAlive();
    }

    void DisplayLives() {
        this.livesText.text = "Lives: " + playerLives.ToString("0");
    }

    void DisplayTime() {
        this.timeText.text = "Time: " + (this.startTime - Time.timeSinceLevelLoad).ToString("0s");

        if (startTime - Time.timeSinceLevelLoad <= 0) {
            SceneManager.LoadScene("Defeat");
        }
    }

    void IsPlayerAlive() {
        if (isPlayerAlive == true && playerLives > 0) {
            isPlayerAlive = true;
        } else {
            isPlayerAlive = false;
            SceneManager.LoadScene("Defeat");
        }
    }
}