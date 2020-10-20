using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    bool isPlayerAlive = true;

    public Text livesText;
    public int playerLives = 3;

    void Update() {
        DisplayLives();
        IsPlayerAlive();
    }

    void IsPlayerAlive() {
        if (playerLives > 0) {
            isPlayerAlive = true;
        } else {
            isPlayerAlive = false;
            SceneManager.LoadScene("Defeat");
        }
    }

    void DisplayLives() {
        this.livesText.text = "Lives: " + playerLives.ToString("0");
    }
}