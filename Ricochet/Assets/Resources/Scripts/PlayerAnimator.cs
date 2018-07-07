using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float ha = Input.GetAxisRaw("Horizontal");
        float va = Input.GetAxisRaw("Vertical");

        if (ha > 0)
        {
            transform.localScale = new Vector3(1, 1, 0);
            anim.Play(Animator.StringToHash("Run"));
        }
        else if (ha < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
            anim.Play(Animator.StringToHash("Run"));
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
            anim.Play(Animator.StringToHash("Stand"));
        }
        
        
    }
}
