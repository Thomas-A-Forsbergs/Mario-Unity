using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text timeText;
    public float startTime;

    void Start() {
        this.startTime = 20;
    }

    void Update() {
        DisplayTime();
        IfTimerIsZeroPlayerIsDefeated();
    }

    void DisplayTime() {
        this.timeText.text = "Time: " + (this.startTime - Time.timeSinceLevelLoad).ToString("0s");
    }

    void IfTimerIsZeroPlayerIsDefeated() {
        if (startTime - Time.timeSinceLevelLoad <= 0) {
            SceneManager.LoadScene("Defeat");
        }
    }
}