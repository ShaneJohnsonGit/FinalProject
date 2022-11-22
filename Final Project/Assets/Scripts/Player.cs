using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontalMovement;
    Rigidbody2D rb;
    bool isJumping = false;
    public float speed = 10;
    public float jumppow = 200;
    public int health = 3;
    int jump = 0;
    bool Invincible = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        isJumping = Input.GetAxis("Jump") > 0 ? true : false;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
        if (isJumping&& jump==0)
        {
            jump++;
            rb.AddForce(Vector2.up * 200);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        jump = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamageTaken();
        }
    }
    private void DamageTaken()
    {
        if (Invincible == false)
        {
            rb.AddForce(Vector2.up * 200);
            health--;
            Invincible = true;
            Invoke("InvincibilityFrames", 2.0f);
        }
        if (health == 0)
        {
            Destroy(this);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); //does not work in the editor, it works when you compile
#endif
        }
    }
    private void InvincibilityFrames()
    {
        Invincible = false;
    }
}
