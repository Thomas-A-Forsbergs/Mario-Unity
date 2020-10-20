using UnityEngine;

public class EnemyMobile : MonoBehaviour {
    Rigidbody2D enemyRB;

    public float movementAcceleration = 10f;
    public float maxSpeed = 1f;

    void Start() {
        enemyRB = this.gameObject.GetComponent<Rigidbody2D>();
        playerManager = playerManagerGameObject.GetComponent<PlayerManager>();
    }

    void Update() {
        Movement();
    }

    void Movement() {
        //float xMovement = Random.Range(0f, 1f);
        float xMovement = 1;

        if (enemyRB.velocity.magnitude < maxSpeed) {
            Vector2 movement = new Vector2(xMovement, 0);
            enemyRB.AddForce(movementAcceleration * movement);
        }
    }

    public GameObject playerManagerGameObject;
    public PlayerManager playerManager;

    public EnemyMobile(GameObject playerManagerGameObject) {
        this.playerManagerGameObject = playerManagerGameObject;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            playerManager.playerLives--;
        }
    }
}