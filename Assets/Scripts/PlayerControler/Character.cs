using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField]
    private LayerMask jumpableGround;
    public Animator animator { get; private set; }
    public Rigidbody2D rigidbody { get; private set; }
    public BoxCollider2D boxCollider2D { get; private set; }

    private ResetScene resetScene;
    
    public float moveSpeed { get; } = 250.0f;
    public float jumpForce { get; } = 10.0f;
    public int health { get; set; } = 1;
    #region
    public State currentState { get; set; }
    public StateMachine stateMachine { get; private set; }

    public State moveState { get; private set; } 
    public State jumpState { get; private set; } 
    public State dieState { get; private set; } 
    #endregion

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        stateMachine = new StateMachine(this);
        moveState  = new MoveState(stateMachine,this);
        jumpState  = new JumpState(stateMachine,this);
        dieState  = new DieState(stateMachine,this);
        currentState = moveState;
    }

    private void Update()
    {
       currentState.Update();
       currentState.Jump();
       
    }

    private void FixedUpdate()
    {
        currentState.Move();
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
        animator.SetBool("isJumping", true);
    }

    public bool CheckIsGrounded(BoxCollider2D boxCollider)
    {
        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(jumpableGround);
        bool isGrounded = boxCollider2D.GetContacts(contactFilter2D, contacts) > 0;
        Debug.Log($"Is grounded: {isGrounded}"); 
        return isGrounded;
    }

    public void InitializeState(State state) 
    {
        currentState = state;
        state.Enter();
    }

    public void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnEnable()
    {
        resetScene = animator.GetBehaviour<ResetScene>();
        resetScene.OnActionRestart += stateMachine.SceneRestert;
    }

}
