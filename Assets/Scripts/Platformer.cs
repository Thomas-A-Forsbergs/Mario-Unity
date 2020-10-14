using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platformer : MonoBehaviour {
    Rigidbody2D rbPlayer;
    public float speedPlayer = 0;
    public float jumpForcePlayer = 0;
    
    // Start is called before the first frame update
    void Start() {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpForcePlayer();  
    }

    void FixedUpdate() {
        
    }

    void MovePlayer() {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speedPlayer;
        rbPlayer.velocity = new Vector2(moveBy,rbPlayer.velocity.y);
    }

    void JumpForcePlayer() {
        if (Input.GetKeyDown(KeyCode.Space) && rbPlayer.position.y<0.1) {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForcePlayer);
        }
    }
}
