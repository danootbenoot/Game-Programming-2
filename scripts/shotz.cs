using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class shotz : MonoBehaviour
{

    float moveSpeed = 7f;

    Rigidbody2D rb;

    playercontroller target;

    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        target = GameObject.FindObjectOfType<playercontroller>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);

        if (other.gameObject.tag == ("Player")) 
        {
            Debug.Log("Hit");
            SceneManager.LoadScene("level_2");
        }
    }
}
