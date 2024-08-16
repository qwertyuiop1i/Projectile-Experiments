using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShell : MonoBehaviour
{
    public float explodeTime = 0.5f;

    public Rigidbody2D rb;
    public float speed = 10f;

    public GameObject shrapnelPrefab;
    public int shrapnelCount;
    public float angleRange;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0f;

        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        
        timer += Time.deltaTime;
        if (timer >= explodeTime)
        {
            Split();
            Destroy(gameObject);
        }
    }

    void Split()
    {
        for (int i = 0; i < shrapnelCount; i++)
        {
            GameObject childBullet = Instantiate(shrapnelPrefab, transform.position, Quaternion.Euler(0, 0,rb.rotation+Random.Range(-angleRange,angleRange)));



   
        }
    }
}
