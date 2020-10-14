using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour {
    public int scoreCount = 0;
    public Text scoreText;

    public void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
        scoreCount++;
        SceneManager.LoadScene("Victory");
        //scoreText.text = "Evidence collected: " + scoreCount;
        //scoreText.text = "Level is completed!\nAll evidence collected.";
        
        // startButton.SetBool("isHidden", true);
    }
}
