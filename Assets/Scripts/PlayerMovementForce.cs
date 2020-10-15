using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementForce : MonoBehaviour {
    Rigidbody2D playerRB;

    public float movementAcceleration = 10f;
    public float maxSpeed = 1f;
    public float jumpAcceleration = 100f;

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

    void Start() {
        playerRB = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Movement();
        Jump();
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
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector2 jumpForce = new Vector2(0, jumpAcceleration);
            playerRB.AddForce(jumpForce);
        }
    }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     if (CollisionIsWithGround(collision)) {
    //         isPlayerGrounded = true;
    //     }
    // }
    //
    // void OnCollisionExit2D(Collision2D collision) {
    //     if (!CollisionIsWithGround(collision)) {
    //         isPlayerGrounded = false;
    //     }
    // }
    //
    // bool CollisionIsWithGround(Collider2D collision) {
    //     bool isWithGround = false;
    //     foreach (ContactPoint2D c in collision.contacts) {
    //         Vector2 collisionDirectionVector = c.point - playerRB.position;
    //         if (collisionDirectionVector.y < 0) {
    //             isWithGround = true;
    //         }
    //     }
    //     return isWithGround;
    // }
}