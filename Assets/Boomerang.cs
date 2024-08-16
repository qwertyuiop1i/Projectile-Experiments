using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 10f;

    public float maxDistance = 10f;
    public bool homing = true;
    public float homingForce = 2f;

    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private bool returning = false;
    private Transform player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        if (!returning && Vector2.Distance(initialPosition, transform.position) >= maxDistance)
        {
            returning = true;

        }

        if (returning && homing)
        {
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            rb.velocity = Vector3.Lerp(rb.velocity,(directionToPlayer * homingForce * Vector2.Distance(player.position, transform.position)),Time.deltaTime);
        }

        if (rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        if (returning&&Vector2.Distance(transform.position, player.position) < 1.2f) { Destroy(gameObject); }
    }


}
