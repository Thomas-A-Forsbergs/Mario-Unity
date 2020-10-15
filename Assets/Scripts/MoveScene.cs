﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour {
    public Button moveScene;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            buttonCallBack();
        }
    }

    void OnEnable() {
        moveScene.onClick.AddListener(() => buttonCallBack());
    }
    
    private void buttonCallBack() {
        //Debug.Log("Clicked: " + moveScene.name);
        var scene = SceneManager.GetActiveScene().name;
        if (scene=="Start") {
            SceneManager.LoadScene(1);
        } else if (scene=="Victory") {
            SceneManager.LoadScene(1);
        } else if (scene=="Defeat") {
            SceneManager.LoadScene(1);
        }
    }

    void OnDisable() {
        moveScene.onClick.RemoveAllListeners();
    }
}
