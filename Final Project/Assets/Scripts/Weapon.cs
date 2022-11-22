using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    bool attack;
    Collider2D collider;
    void Start()
    {
        
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
        }
        
    } 
}
