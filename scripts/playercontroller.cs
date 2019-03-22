using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    //create variables
    private float moveInput;
    private Rigidbody2D rb;
    public float speed;

    private bool faceR = true;

    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;

    // Start is called before the first frame update
    //call for the rigidbody
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    //time is important to physics, so we need the time to be constant regardless of lag and dumb shit
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (faceR == true && moveInput < 0)
        {
            Flip();
        }
        else if (faceR == false && moveInput > 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        faceR = !faceR;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "open")
        {
            SceneManager.LoadScene("level_1");
        }

        if (other.gameObject.tag == "opener")
        {
            SceneManager.LoadScene("level_2");
        }

        if (other.gameObject.tag == "damage")
        {
            SceneManager.LoadScene("level_1");
        }
        if (other.gameObject.tag == "damaged")
        {
            SceneManager.LoadScene("level_2");
        }
        if (other.gameObject.tag == "restart")
        {
            SceneManager.LoadScene("start_scene");
        }
        if (other.gameObject.tag == "win")
        {
            SceneManager.LoadScene("wins");
        }

    }

}


