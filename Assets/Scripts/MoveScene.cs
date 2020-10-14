using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour {
    public Button moveScene;

    void OnEnable() {
        moveScene.onClick.AddListener(() => buttonCallBack());
    }
    
    private void buttonCallBack() {
        Debug.Log("Clicked: " + moveScene.name);
        var scene = SceneManager.GetActiveScene().name;
        if (scene=="2D") {
            SceneManager.LoadScene("Victory");
        } else if (scene=="Victory") {
            SceneManager.LoadScene("2D");
        }
    }

    void OnDisable() {
        moveScene.onClick.RemoveAllListeners();
    }
}
