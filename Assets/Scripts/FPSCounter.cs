using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {
    public Text fpsDisplay;
    public Text averageFPSDisplay;
    int framesPassed = 0;
    float fpsTotal = 0f;
    public Text minFPSDisplay, maxFPSDisplay;
    float minFPS = Mathf.Infinity;
    float maxFPS = 0f;

    void Start() {
        Application.targetFrameRate = 144;
    }

    void Update() {
        //var fps = 0.001f * Time.unscaledDeltaTime;
        var fps = 1 / Time.unscaledDeltaTime;
        fpsDisplay.text = "Current: " + fps.ToString("0.0 FPS");

        fpsTotal += fps;
        framesPassed++;
        averageFPSDisplay.text = "Average: " + (fpsTotal / framesPassed).ToString("0.0 FPS");

        if (fps > maxFPS && framesPassed > 10) {
            maxFPS = fps;
            maxFPSDisplay.text = "Max: " + maxFPS.ToString("0.0 FPS");
        }

        if (fps < minFPS && framesPassed > 10) {
            minFPS = fps;
            minFPSDisplay.text = "Min: " + minFPS.ToString("0.0 FPS");
        }
    }
}