using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Movement : MonoBehaviour
{
    Rigidbody2D myrigidbody2D;
    [SerializeField] float SpeedJump = 20f;

    public TextMeshProUGUI textMeshPro;
    int tong = 0;
    int coinMax = 6;
    public GameObject startGame;
    Animator animator;
    private bool nen;
    private bool isJumping = false;
    private bool isGrounded = false;
    public bool isRight = true;
    private bool isMoving = false;
    void count(int score)
    {
        tong += score;
        textMeshPro.text = "Poin :" + tong;
    }

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        count(0);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Jumping()
    {
        if (nen == true && isGrounded)
        {
            myrigidbody2D.velocity += new Vector2(0f, SpeedJump);
        }
        nen = false;
        isJumping = true;

    }

    public void RuningLeft()
    {
        isRight = false;
        myrigidbody2D.velocity = new Vector2(-5f, myrigidbody2D.velocity.y);
        FlipCharacterScale();
        UpdateMovementAnimation();
    }

    public void RuningRight()
    {
        isRight = true;
        myrigidbody2D.velocity = new Vector2(5f, myrigidbody2D.velocity.y);
        FlipCharacterScale();
        UpdateMovementAnimation();
    }

    private void FlipCharacterScale()
    {
        Vector2 scale = transform.localScale;
        scale.x = isRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    private void UpdateMovementAnimation()
    {
        isMoving = Mathf.Abs(myrigidbody2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRuning", isMoving);
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coin")
        {
            Destroy(other.gameObject, 0f);
            count(1);
        }
        if (coinMax == tong)
        {
            startGame.SetActive(true);
        }
    }
    public void PlayGame()
    {
        startGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            nen = true;
            isJumping = false;
            isGrounded = true;
        }


    }
}
