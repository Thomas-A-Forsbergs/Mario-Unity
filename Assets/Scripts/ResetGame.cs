using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour {
    public Button resetButton;

    Vector2 defaultPosition;
    Vector2 defaultScale;
    Quaternion defaultRotation;

    // Start is called before the first frame update
    void Start() {
        defaultPosition = transform.position;
        defaultScale = transform.localScale;
        defaultRotation = transform.rotation;
    }

    void OnEnable() {
        resetButton.onClick.AddListener(() => buttonCallBack());
    }

    private void buttonCallBack() {
        Debug.Log("Clicked: " + resetButton.name);
        resetGameData();
    }

    void resetGameData() {
        transform.position = defaultPosition;
        transform.localScale = defaultScale;
        transform.rotation = defaultRotation;
    }

    // public void ButtonClick() {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}