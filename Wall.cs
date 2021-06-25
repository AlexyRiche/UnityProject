using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public GameObject ship;
    bool isDestructible = false;
    Color[] colors = new Color[4];
    SpriteRenderer wallSpriteRenderer;
    Transform wallTransform;
    Rigidbody2D rb;

    private Vector2 screenBounds;
    void Start()
    {
        wallSpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        wallTransform = GetComponent<Transform>();
        //wall scroling
        rb.velocity = -transform.right * speed;
        // initialise colors
        colors[0] = Color.magenta;
        colors[1] = Color.blue;
        colors[2] = Color.red;
        colors[3] = Color.green;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        generateNewWall();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void generateNewWall() {
        if (Random.Range(0, 101) < 50) {
            isDestructible = false;
            wallSpriteRenderer.color = colors[0];
        } else {
            isDestructible = true;
            wallSpriteRenderer.color = colors[Random.Range(1, 4)];
        }
    }

    public void Hit(bulletInteraction bullet) {
        if (isDestructible) {
            if (wallSpriteRenderer.color == bullet.getColor()) {
                Destroy(gameObject);
            }
        }
    }
}
