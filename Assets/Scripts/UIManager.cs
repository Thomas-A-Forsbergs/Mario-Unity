using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text timeText;
    float startTime = 0f;
    
    // Start is called before the first frame update
    void Start() {
        this.startTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        this.timeText.text = (Time.time - this.startTime).ToString("Time: 0.000s");
    }
}
