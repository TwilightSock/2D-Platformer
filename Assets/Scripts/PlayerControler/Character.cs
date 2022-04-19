using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    #region LayerMask
    [SerializeField]
    private LayerMask jumpableGround;
    #endregion

    #region Character Attachments
    public Animator animator { get; private set; }
    public Rigidbody2D rigidbody { get; private set; }
    public BoxCollider2D boxCollider2D { get; private set; }
    #endregion
    #region GameControllers
    private ResetScene resetScene;
    [SerializeField]
    private GameController gameController;
    #endregion
    #region Character values
    public float moveSpeed { get; } = 250.0f;
    public float jumpForce { get; } = 10.0f;
    public int health { get; set; } = 1;
    public bool inAir { get; set; } = false;

    #region States

    #endregion

    #endregion
    #region Animation Values

    public int isJumping { get; set; } = Animator.StringToHash("isJumping");
    public int isMoving { get; set; } = Animator.StringToHash("isMoving");
    public int isDying { get; set; } = Animator.StringToHash("isDying");

    #endregion
    public 
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        JumpPlayer(); 
        if (health <= 0)
        {
            invokeAnimation(isDying,true);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(Input.GetAxis("Horizontal"));
    }

    public void MovePlayer(float playerSpeed)
    {
        bool move = false;
        if (!Mathf.Approximately(playerSpeed, 0))
        {
            move = true;
            transform.localScale = new Vector3(Mathf.Sign(playerSpeed), 1, 1);
        }
        rigidbody.velocity = new Vector2(playerSpeed *moveSpeed* Time.deltaTime, rigidbody.velocity.y);
        
        invokeAnimation(isMoving, move);
    }

    public void JumpPlayer()
    {
        bool jump = !CheckIsGrounded(boxCollider2D);
        if (Input.GetButtonDown("Jump") && CheckIsGrounded(boxCollider2D))
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        invokeAnimation(isJumping,jump);
    }

    public void invokeAnimation(int param,bool value)
    {
        animator.SetBool(param, value);
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

    // public void InitializeState(State state) 
    // {
    //     currentState = state;
    //     state.Enter();
    // }


    public void OnEnable()
    {
        resetScene = animator.GetBehaviour<ResetScene>();
        gameController.SceneEditor(ref resetScene.onActionRestart); 
       
    }

    private void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
