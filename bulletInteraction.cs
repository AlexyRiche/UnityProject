using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletInteraction : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public Rigidbody2D rb;
    SpriteRenderer _spriteR;

    void Start()
    {
        rb.velocity = transform.up * speed;
        _spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
    public Color getColor() {
        return _spriteR.color;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Wall wall = other.GetComponent<Wall>();
        if (wall) {
            wall.Hit(this);
        }
        Destroy(gameObject);
    }
}
