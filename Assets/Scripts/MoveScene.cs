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
        if (scene=="Start") {
            SceneManager.LoadScene("2D");
        } else if (scene=="Victory") {
            SceneManager.LoadScene("2D");
        } else if (scene=="Defeat") {
            SceneManager.LoadScene("2D");
        }
    }

    void OnDisable() {
        moveScene.onClick.RemoveAllListeners();
    }
}
