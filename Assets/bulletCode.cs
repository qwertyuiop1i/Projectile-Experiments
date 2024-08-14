using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class bulletCode : MonoBehaviour
{
    public Rigidbody2D rb;
    public Light2D ld;
    public ParticleSystem ps;
    public float bulletSpeed = 15f;
    // Start is called before the first frame update
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
        rb.velocity = transform.up * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
