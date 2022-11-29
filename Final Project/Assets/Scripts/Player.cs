using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    float horizontalMovement;
    Rigidbody2D rb;
    bool isJumping = false;
    bool dashing;
    public float speed = 10;
    public float jumppow = 200;
    public int health = 3;
    public Image[] hearts;
    Vector3 respawnPoint;
    int jump = 0;
    bool level2 = false;
    bool cooldown=true;
    int length;
    bool Invincible = false;
    Text available;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
            respawnPoint = transform.position;
        length = hearts.Length - 1;
        if (SceneManager.GetActiveScene().name == "level 2")
        {
            level2 = true;
            available = GameObject.Find("teleportCooldown").GetComponent<Text>();
            health = PlayerPrefs.GetInt("Health");
            Debug.Log(health);
            int temphealth = health-1;
            while (temphealth < length)
            {
                temphealth++;
                hearts[temphealth].enabled = false;
                
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        isJumping = Input.GetAxis("Jump") > 0 ? true : false;
        dashing = Input.GetAxis("Fire2") > 0 ? true : false;
        
    }
    private void FixedUpdate()
    {
        if (transform.position.y < -10)
        {
            DamageTaken();
            
            rb.velocity = Vector3.zero;
            transform.position = respawnPoint;
            
        }
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
        if (isJumping&& jump==0)
        {
            jump++;
            rb.AddForce(Vector2.up * 200);
        }
        if (dashing&&level2)
        {
            dash();
        }
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        jump = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Invincible == false)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                DamageTaken();
                rb.AddForce(Vector2.up * 200);
            }
        }
    }
    private void DamageTaken()
    {
        
            
            health--;
            Invincible = true;
            hearts[length].enabled = false;
            length--;
            Invoke("InvincibilityFrames", 2.0f);
            
            
        
        if (health == 0)
        {
            Destroy(this);
            SceneManager.LoadScene("Lose");
        }
    }
    private void InvincibilityFrames()
    {
        Invincible = false;
    }
    private void dash()
    {
        if (cooldown)
        {
            if (transform.localScale.x < 0)
            {
                transform.Translate(new Vector3(transform.position.x - 5, transform.position.y, transform.position.z));
            }
            else if (transform.localScale.x > 0)
            {
                transform.Translate(new Vector3(transform.position.x+5, transform.position.y, transform.position.z));
            }
            cooldown = false;
            available.text = "Teleport:Unavailable";
            Invoke("TeleportCooldown", 3.0f);
        }

    }
    private void TeleportCooldown()
    {
        available.text = "Teleport:Available";
        cooldown = true;
    }
}
