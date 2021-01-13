using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator animator;
    public float fuerzaSalto;
    private Rigidbody2D rigidbody2D;
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJump", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "suelo")
        {
            animator.SetBool("isJump", false);

        }
        if(collision.gameObject.tag == "Obstaculos")
        {
            GameManager.gameOver = true;
        }
    }


}
