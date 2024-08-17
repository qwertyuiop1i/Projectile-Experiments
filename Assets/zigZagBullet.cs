using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class zigZagBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Light2D ld;
    public ParticleSystem ps;
    public float bulletSpeed = 15f;
    public float zigzagAmplitude = 1f;
    public float zigzagFrequency = 2f;

    private float startTime;
    private Vector2 initialDirection;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
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

        startTime = Time.time;
        initialDirection = transform.up;
        rb.velocity = initialDirection * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Mathf.Sin((Time.time - startTime) * zigzagFrequency) * zigzagAmplitude;
        Vector2 direction = initialDirection + offset * new Vector2(-initialDirection.y, initialDirection.x);
        rb.velocity = direction * bulletSpeed;
    }
}
