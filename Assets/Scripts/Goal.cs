using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    public int scoreCount = 0;
    public Text scoreText;

    public void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
        var scene = SceneManager.GetActiveScene().name;
        if (scene == "Level01") {
            SceneManager.LoadScene("Victory");
        } else if (scene == "Level02") {
            SceneManager.LoadScene("Credits");
        }

        //scoreCount++;
        //scoreText.text = "Evidence collected: " + scoreCount;
        //scoreText.text = "Level is completed!\nAll evidence collected.";

        // startButton.SetBool("isHidden", true);
    }
}