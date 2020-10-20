using UnityEngine;

public class EnemyStationary : MonoBehaviour {

    public GameObject playerManagerGameObject;
    public PlayerManager playerManager;

    public EnemyStationary(GameObject playerManagerGameObject) {
        this.playerManagerGameObject = playerManagerGameObject;
    }

    void Start() {
        playerManager = playerManagerGameObject.GetComponent<PlayerManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            playerManager.playerLives--;
        }
    }
}