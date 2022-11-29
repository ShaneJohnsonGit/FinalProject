using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    bool down=true;
    int count;
    public bool left=true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (left)
        {
            rb.AddForce(Vector2.left * 100);
        }
        else
        {
            rb.AddForce(Vector2.right * 100);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        
        
        if (down)
        {
            count++;

            rb.AddForce(Vector2.down * 5);
            hover();
            
        }
        else if (down == false)
        {
            count++;
            rb.AddForce(Vector2.up * 5);
            hover();
            
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void hover()
    {
        if (count == 20)
        {
            count = 0;
            if (down)
            {
                down = false;
                rb.AddForce(Vector2.down * -100);
            }
            else
            {
                down = true;

                rb.AddForce(Vector2.up * -100);
            }

        }
    }

}
