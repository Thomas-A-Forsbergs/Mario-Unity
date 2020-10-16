using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementVelocity : MonoBehaviour {
    Rigidbody2D playerRB;

    public float playerSpeed = 1f;
    
    public float playerJumpForce = 1f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public int defaultAdditonalJumps = 1;
    int additionalJumps;
    bool isPlayerGrounded = false;
    public Transform isGroundedChecker1;
    public Transform isGroundedChecker2;
    public float checkGroundRadius;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    public LayerMask groundLayer;
    
    public int playerLives = 1;
    bool isPlayerAlive = true;

    // Start is called before the first frame update
    void Start() {
        playerRB = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        PlayerMove();
        PlayerJumpForce();
        CheckIfGrounded();
        PlayerClassicJump();
        IsPlayerAlive();
    }

    void PlayerMove() {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float moveBy = xMovement * playerSpeed;
        playerRB.velocity = new Vector2(moveBy, playerRB.velocity.y);
        
        // if (x == 1) {
        //     SpriteRenderer.flipX = false;
        // } else if (x == -1) {
        //     SpriteRenderer.flipX = true;
        // }
    }

    void PlayerJumpForce() {
        if (Input.GetKeyDown(KeyCode.Space) && (isPlayerGrounded ||
                                                Time.time - lastTimeGrounded <= rememberGroundedFor ||
                                                additionalJumps > 0)) {
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpForce);
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
        Collider2D collider2D = Physics2D.OverlapArea(isGroundedChecker1.position,
            isGroundedChecker2.position, groundLayer);

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
        if (isPlayerAlive == true && playerRB.position.y > -5) {
            isPlayerAlive = true;
        } else {
            isPlayerAlive = false;
            SceneManager.LoadScene("Defeat");
        }
    }
}