using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    [SerializeField]
    private LayerMask jumpableGround;
    public Animator animator { get; private set; }
    public Rigidbody2D rigidbody { get; private set; }
    public BoxCollider2D boxCollider2D { get; private set; }
    
    public float moveSpeed { get; } = 250.0f;
    public float jumpForce { get; } = 10.0f;
    public int health { get; set; } = 1;
    #region
    public State currentState { get; set; }

    public State moveState { get; } = new MoveState();
    public State jumpState { get; } = new JumpState();
    public State dieState { get; } = new DieState();
    #endregion

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        currentState = moveState;
    }

    private void Update()
    {
       currentState.HandleInput(this);
       currentState.LogicUpdate(this);
       currentState.UpdateState(this);
       
    }
    public void FixedUpdate()
    {
        currentState.PhysicsUpdateState(this);
    }
    public void MovePlayer(float playerSpeed)
    {
        bool isMoving = false;
        if (!Mathf.Approximately(playerSpeed, 0))
        {
            isMoving = true;
            transform.localScale = new Vector3(Mathf.Sign(playerSpeed), 1, 1);
        }
        rigidbody.velocity = new Vector2(playerSpeed *moveSpeed* Time.deltaTime, rigidbody.velocity.y);
        
        animator.SetBool("isMoving", isMoving);
    }

    public void JumpPlayer()
    {       
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetBool("isJumping",true);
    }

    public bool CheckIsGrouded(BoxCollider2D boxCollider)
    {
        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(jumpableGround);
        bool isGrounded = boxCollider2D.GetContacts(contactFilter2D, contacts) > 0;
        Debug.Log($"Is grounded: {isGrounded}"); 
        return isGrounded;
    }

    public void InitiaizeState(State state) 
    {
        currentState = state;
        state.Enter(this);
    }
}
