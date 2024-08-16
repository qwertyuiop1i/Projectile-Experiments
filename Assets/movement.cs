using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed= 5f;
    private Rigidbody2D
 rb;
    public GameObject[] bulletPrefabs;
    public Transform firePoint;
    private int currentBulletIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");


        Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

        rb.velocity = moveDirection * speed;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y,
 direction.x) * Mathf.Rad2Deg
 - 90f;

        rb.rotation = angle;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentBulletIndex = (currentBulletIndex + 1) % bulletPrefabs.Length;
        }
    }

    public void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefabs[currentBulletIndex], firePoint.position, firePoint.rotation);
    }
}