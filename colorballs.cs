using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorballs : MonoBehaviour
{
    public float speed = 5f;
    public GameObject ship;
    Color[] colors = new Color[3];
    SpriteRenderer _Rsprite;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.blue;
        colors[1] = Color.red;
        colors[2] = Color.green;

        _Rsprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _Rsprite.color = colors[Random.Range(0, 3)];

        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Wall wall = other.GetComponent<Wall>();
        if (wall)
        {
            Destroy(gameObject);
        }
    }

    public void destroyBall()
    {
        Destroy(gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
