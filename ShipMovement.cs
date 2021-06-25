using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int movementSpeed = 1;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public Joystick joystick;

    private int score = 0;
    SpriteRenderer shipSpriteRenderer;
    SpriteRenderer bulletSpriteRenderer;
    Color[] colors = new Color[3];
    int selectedColor = 0;
    public GameOverScreen gameOverScreen;

    void Start()
    {
        shipSpriteRenderer = GetComponent<SpriteRenderer>();
        colors[0] = Color.blue;
        colors[1] = Color.red;
        colors[2] = Color.green;
        shipSpriteRenderer.color = colors[0];
    }

    
    void Update()
    {
        // Movement
        /* var vertical = Input.GetAxis("Vertical");*/
        var vertical = joystick.Vertical;
        if (transform.position.y < Screen.height) {
            transform.position += new Vector3(0, vertical, 0) * Time.deltaTime * movementSpeed;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(1);

            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    Shoot();
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                 
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                 
                 
                    break;
            }


        }

        // Fire bullet
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }

        // Change Ship color
        if (Input.GetKeyDown(KeyCode.A)) {
            changeShipColor();
        }

    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);
        bullet.GetComponent<SpriteRenderer>().color = shipSpriteRenderer.color;
    }

    void changeShipColor() {
        if (selectedColor == 2) {
            selectedColor = 0;
        } else {
            selectedColor++;
        }
        shipSpriteRenderer.color = colors[selectedColor];
    }

    
    void Die() {
        gameOverScreen.Setup(score);
        gameObject.SetActive(false);
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Wall wall = other.GetComponent<Wall>();
        if (wall) {
            Die();
        }

        colorballs colorBall = other.GetComponent<colorballs>();
        if (colorBall)
        {
            shipSpriteRenderer.color = colorBall.GetComponent<SpriteRenderer>().color;
            colorBall.destroyBall();
            

        }
    }
}
