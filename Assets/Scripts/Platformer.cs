using UnityEngine;
using UnityEngine.SceneManagement;

public class Platformer : MonoBehaviour {
    Rigidbody2D rbPlayer;
    SpriteRenderer srPlayer;

    public float speedPlayer = 0f;
    public float jumpForcePlayer = 0f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public int defaultAdditonalJumps = 1;
    int additionalJumps;
    public int livesPlayer = 1;
    bool isAlivePlayer = true;

    bool isGroundedPlayer = false;
    public Transform isGroundedChecker1;
    public Transform isGroundedChecker2;
    public float checkGroundRadius;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start() {
        rbPlayer = GetComponent<Rigidbody2D>();
        srPlayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        MovePlayer();
        JumpForcePlayer();
        CheckIfGrounded();
        ClassicJumpPlayer();
        IsAlivePlayer();
    }

    void MovePlayer() {
        float x = Input.GetAxisRaw("Horizontal");
        // if (x == 1) {
        //     SpriteRenderer.flipX = false;
        // } else if (x == -1) {
        //     SpriteRenderer.flipX = true;
        // }

        float moveBy = x * speedPlayer;
        rbPlayer.velocity = new Vector2(moveBy, rbPlayer.velocity.y);
    }

    void JumpForcePlayer() {
        if (Input.GetKeyDown(KeyCode.Space) && (isGroundedPlayer ||
                                                Time.time - lastTimeGrounded <= rememberGroundedFor ||
                                                additionalJumps > 0)) {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForcePlayer);
            additionalJumps--;
        }
    }

    void ClassicJumpPlayer() {
        if (rbPlayer.velocity.y < 0) {
            rbPlayer.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rbPlayer.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rbPlayer.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded() {
        Collider2D collider2D = Physics2D.OverlapArea(isGroundedChecker1.position,
            isGroundedChecker2.position, groundLayer);

        if (collider2D != null) {
            isGroundedPlayer = true;
            additionalJumps = defaultAdditonalJumps;
        } else {
            if (isGroundedPlayer) {
                lastTimeGrounded = Time.time;
            }

            isGroundedPlayer = false;
        }
    }

    void IsAlivePlayer() {
        if (isAlivePlayer == true && rbPlayer.position.y > -5) {
            isAlivePlayer = true;
        } else {
            isAlivePlayer = false;
            SceneManager.LoadScene("Defeat");
        }
    }
}