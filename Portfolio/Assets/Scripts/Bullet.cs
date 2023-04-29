using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Rigidbody2D rb;
    //vfx
    [SerializeField] GameObject explosionParticles;
    //sfx
    AudioSource audioSource;
    [SerializeField] AudioClip explosionSfx;
    //shake
    Animator animator;
    private void Start()
    {
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        animator = Camera.main.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        rb.velocity = Vector2.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Alien")
        {
            Explosion();
            Application.OpenURL(collision.gameObject.GetComponent<AlienURL>().GetURL());
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Asteroid")
        {
            Explosion();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

   void Explosion()
    {
        animator.SetTrigger("Shake");
        audioSource.PlayOneShot(explosionSfx, 0.4f);
        GameObject explosionObj = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(explosionObj, 0.5f);
    }
}
