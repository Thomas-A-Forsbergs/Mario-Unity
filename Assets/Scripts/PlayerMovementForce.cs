using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementForce : MonoBehaviour {
    Rigidbody2D playerRB;

    public float movementAcceleration = 10f;
    public float maxSpeed = 1f;

    public float jumpForce = 100f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public int defaultAdditonalJumps = 1;
    int additionalJumps;
    bool isPlayerGrounded = false;
    public Transform isGroundedCheckerLeft;
    public Transform isGroundedCheckerRight;
    public float checkGroundRadius;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    public LayerMask groundLayer;

    
    bool isPlayerAlive = true;

    void Start() {
        playerRB = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Movement();
        Jump();
        CheckIfGrounded();
        IsPlayerAlive();
    }

    void FixedUpdate() {
        //Movement();
        //Jump();
    }

    void Movement() {
        float xMovement = Input.GetAxisRaw("Horizontal");

        if (playerRB.velocity.magnitude < maxSpeed) {
            Vector2 movement = new Vector2(xMovement, 0);
            playerRB.AddForce(movementAcceleration * movement);
        }
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && (isPlayerGrounded ||
                                                Time.time - lastTimeGrounded <= rememberGroundedFor ||
                                                additionalJumps > 0)) {
            Vector2 jumpForce = new Vector2(0, this.jumpForce);
            playerRB.AddForce(jumpForce);
            additionalJumps--;
        }
    }

    void PlayerClassicJump() {
        if (playerRB.velocity.y < 0) {
            playerRB.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (playerRB.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            playerRB.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded() {
        Collider2D collider2D = Physics2D.OverlapArea(isGroundedCheckerLeft.position,
            isGroundedCheckerRight.position, groundLayer);

        if (collider2D != null) {
            isPlayerGrounded = true;
            additionalJumps = defaultAdditonalJumps;
        } else {
            if (isPlayerGrounded) {
                lastTimeGrounded = Time.time;
            }

            isPlayerGrounded = false;
        }
    }

    void IsPlayerAlive() {
        if (isPlayerAlive == true && playerRB.position.y >= -5) {
            isPlayerAlive = true;
        } else {
            isPlayerAlive = false;
            SceneManager.LoadScene("Defeat");
        }
    }
}