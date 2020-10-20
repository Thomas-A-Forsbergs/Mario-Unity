using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            MoveToVictoryOrCredits();
        }
    }

    void MoveToVictoryOrCredits() {
        var scene = SceneManager.GetActiveScene().name;
        if (scene == "Level01") {
            SceneManager.LoadScene("Victory");
        } else if (scene == "Level02") {
            SceneManager.LoadScene("Credits");
        }
    }
}