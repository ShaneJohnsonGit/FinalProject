using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    bool attack;
    new Collider2D collider;
    AudioSource soundfx;
    void Start()
    {
        soundfx = GameObject.Find("Weapon").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        attack = Input.GetAxis("Fire1") > 0 ? true : false;
        

    }
    private void FixedUpdate()
    {
        if (attack)
        {
            soundfx.Play();
        }
        if (attack && collider != null)
        {
            Attack(collider);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collider = collision;
    }
    public void Attack(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.GameObject());
            collider = null;
            
        }
        
    } 
}
