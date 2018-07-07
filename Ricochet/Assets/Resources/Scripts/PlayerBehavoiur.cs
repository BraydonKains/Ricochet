using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavoiur : MonoBehaviour {
    const string HorizontalAxis = "Horizontal";
    const string VerticalAxis = "Vertical";
    const string JumpAxis = "Jump";
    const int JumpFrames = 120;
    const int HorizontalScale = 4;
    
    public bool air = false;
    public int jumpFrameCounter = 0;  

    public Rigidbody2D rb;

    void MoveX(float dir) {
        rb.velocity = new Vector2(dir*HorizontalScale, 0);
    }

    void Jump()
    {
        float horizontalVelocity = Input.GetAxis(HorizontalAxis) * HorizontalScale;
        rb.velocity = new Vector2(horizontalVelocity, 0);
        rb.velocity = new Vector2(horizontalVelocity, 7);
        air = true;
        jumpFrameCounter = JumpFrames;
    }
    
    void Fall()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }
 
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!air)
        {
            MoveX(Input.GetAxis(HorizontalAxis));
            if (Input.GetAxis(JumpAxis) == 1) Jump();
        }
        else
        {
            if (jumpFrameCounter > 0) jumpFrameCounter--;
            if (Input.GetAxis(JumpAxis) == 1) Jump();
        }
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Floor")
        {
            if(air)
            {
                air = false;
                jumps = 2;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.name == "Wall" && Input.GetAxis(JumpAxis) == 1 && air)
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y+2);
        }
    }
}
