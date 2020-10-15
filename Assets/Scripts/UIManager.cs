using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [NotNull] public Text timeText;
    float startTime;
    
    [NotNull] public Text livesText;
    int playerLives = 0;

    void Start() {
        this.startTime = Time.time;
        this.playerLives = 1;
    }

    // Update is called once per frame
    void Update() {
        this.timeText.text = (Time.time - this.startTime).ToString("Time: 0.000s");
        this.livesText.text = playerLives.ToString("Lives: 0");
    }
}
