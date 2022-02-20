using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float playerSpeed;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }


    private void MovePlayer() 
    {
        float playerInput = Input.GetAxis("horizontal") * playerSpeed * Time.deltaTime;
        Vector2 movement = new Vector2(playerInput,rigidbody.velocity.y);
        rigidbody.velocity = movement;
    }
}
