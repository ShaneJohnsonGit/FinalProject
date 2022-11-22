using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LungingEnemy : MonoBehaviour
{
    public GameObject target;
    Rigidbody2D rb;
    int count;
    public bool face= false;
    private Vector3 targetTrans;
    bool lungeAvailable=true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        targetTrans = target.transform.position;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (face)
        {
            count++;
            
            rb.AddForce(Vector2.left * 5);
            swapFace();
        }
        else if (face == false)
        {
            count++;
            rb.AddForce(Vector2.right * 5);
            swapFace();
        }
        if (Vector3.Distance(transform.position, target.transform.position) < 3 &&lungeAvailable && transform.position.y > target.transform.position.y)
        {
            if (transform.position.x > target.transform.position.x)
            {
                rb.AddForce(Vector2.left * 300);
                lungeAvailable = false;
                Invoke("Cooldown", 1.0f);
            }
            else
            {
                rb.AddForce(Vector2.right * 300);
                lungeAvailable = false;
                Invoke("Cooldown", 1.0f);
            }

        }
    }
    private void swapFace()
    {
        if (count == 60)
        {
            count = 0;
            if (face)
            {
                face = false;
                rb.velocity = Vector2.zero;
            }
            else
            {
                face = true;

                rb.velocity = Vector2.zero;
            }
            
        }
    }
    private void Cooldown()
    {
        lungeAvailable = true;
    }
}
