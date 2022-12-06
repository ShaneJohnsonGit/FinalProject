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
    Animator anim;
    ParticleSystem part;
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        soundfx = GameObject.Find("Weapon").GetComponent<AudioSource>();
        part =GameObject.Find("Weapon").GetComponent<ParticleSystem>();
       
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
            part.Play();
            StartCoroutine(Animation());
            if (collider != null)
            {

                Attack(collider);
            }
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
    
    IEnumerator Animation()
    {
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(.5f);
        anim.SetBool("isAttack", false);
    }
}
