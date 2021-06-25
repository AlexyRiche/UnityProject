using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    
    public int jumpForce = 1;
    public int movementSpeed = 1;
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * movementSpeed;
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) {
            Debug.Log("hey");
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
