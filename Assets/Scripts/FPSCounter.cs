using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start() {
        Application.targetFrameRate = 144;
    }

    // Update is called once per frame
    void Update() {
        //var fps = 0.001f * Time.unscaledDeltaTime;
        var fps = 1 / Time.unscaledDeltaTime;
        fpsDisplay.text = "" + fps + " FPS";

        fpsTotal += fps;
        framesPassed++;
        averageFPSDisplay.text = "" + (fpsTotal / framesPassed) + " average FPS";

        if (fps > maxFPS && framesPassed > 10) {
            maxFPS = fps;
            maxFPSDisplay.text = "Max: " + maxFPS;
        }
        
        if (fps < minFPS && framesPassed > 10) {
            minFPS = fps;
            minFPSDisplay.text = "Min: " + minFPS;
        }
    }
}