using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    bool grounded = true;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float ha = Input.GetAxisRaw("Horizontal");
        float va = Input.GetAxisRaw("Vertical");

        if (ha > 0 && grounded)
        {
            transform.localScale = new Vector3(1, 1, 0);
            anim.Play(Animator.StringToHash("Run"));
        }
        else if (ha < 0 && grounded)
        {
            transform.localScale = new Vector3(-1, 1, 0);
            anim.Play(Animator.StringToHash("Run"));
        }
        else if (!grounded)
        {
            anim.Play(Animator.StringToHash("Jump"));
        }
        else
        {
            anim.Play(Animator.StringToHash("Stand"));
        }
        if(va != 0)
        {
            transform.localScale = new Vector3(ha, 1, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            grounded = true;

        }
        if(collision.gameObject.name == "Wall")
        {
            Debug.Log("wow");
            gameObject.transform.localScale = new Vector3(transform.localScale.x, 1, 0);
            anim.Play(Animator.StringToHash("Slide"));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor") grounded = false;
    }
}
