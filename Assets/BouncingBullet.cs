using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class BouncingBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Light2D ld;
    public ParticleSystem ps;
    public float bulletSpeed = 15f;
    public float bounceFactor = 0.8f;

    public float lifeTime = 5f;
    public float timer = 0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Vector2 reflection = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);

            rb.velocity = reflection * bulletSpeed * bounceFactor;
        }
    }
    void Start()
    {
        timer = 0f;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (ld == null)
        {
            ld = GetComponent<Light2D>();
        }

        if (ps == null)
        {
            ps = GetComponent<ParticleSystem>();
        }
        rb.velocity = transform.up * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
