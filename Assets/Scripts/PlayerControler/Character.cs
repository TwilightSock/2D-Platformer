using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
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
        if (!Mathf.Approximately(playerSpeed, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(playerSpeed), 1, 1);
        }
        rigidbody.velocity = new Vector2(playerSpeed *moveSpeed* Time.deltaTime, rigidbody.velocity.y);
        
        animator.SetFloat("moving", Mathf.Abs(playerSpeed));
    }

    public void jumpPlayer()
    {
        bool isGrounded = CheckIsGrouded(boxCollider2D);
        Debug.Log(isGrounded);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 1 * jumpForce);
            //rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        animator.SetTrigger("jump");
    }

    public bool CheckIsGrouded(BoxCollider2D boxCollider)
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down * .1f,6);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
}
