using JuiceKit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Elements
{
    public class CharacterElement : Element
    {
        #region
        public Action onCharacterDeath;
        #endregion
        #region LayerMask
        [SerializeField]
        private LayerMask jumpableGround;
        #endregion

        #region Character Attachments
        public Animator animator { get; private set; }
        public Rigidbody2D rigidbody { get; private set; }
        public BoxCollider2D boxCollider2D { get; private set; }       
        #endregion

        #region Character values
        public float moveSpeed { get; } = 250.0f;
        public float jumpForce { get; } = 10.0f;
        private int health { get;  set; } = 1;
        public int coinsCollected { get; private set; } = 0;
        public bool isDead { get; set; } = false;

        #endregion

        #region Sounds
        [SerializeField] private AudioSource deathSound;
        [SerializeField] private AudioSource jumpSound;
        private bool deathSoundPlayed = false;
        #endregion

        #region Animation Values

        public int isJumping { get; set; } = Animator.StringToHash("isJumping");
        public int isMoving { get; set; } = Animator.StringToHash("isMoving");
        public int isDying { get; set; } = Animator.StringToHash("isDying");

        #endregion

        public void OnEnable()
        {
            
        }

        public void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
        }

        public void MovePlayer(float playerSpeed)
        {
            bool move = false;
            if (!Mathf.Approximately(playerSpeed, 0))
            {
                move = true;
                transform.localScale = new Vector3(Mathf.Sign(playerSpeed), 1, 1);
            }
            rigidbody.velocity = new Vector2(playerSpeed * moveSpeed * Time.deltaTime, rigidbody.velocity.y);
            invokeAnimation(isMoving, move);
        }

        public void JumpPlayer(bool playerJump)
        {
            bool jump = !CheckIsGrounded(boxCollider2D);
            if (playerJump && CheckIsGrounded(boxCollider2D))
            {
                rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpSound.Play();
            }
            invokeAnimation(isJumping, jump);
        }

        public void DoDamage(int damage)
        {
            health -= damage;
        }

        public void DiePlayer()
        {
            if (health <= 0)
            {
                isDead = true;
                if (!deathSoundPlayed)
                {
                    deathSound.Play();
                    deathSoundPlayed = true;
                }
                invokeAnimation(isDying, true);
                onCharacterDeath();
            }

        }

        public void OnFall()
        {
            health = 0;
        }

        public void OnCollectItem()
        {
            coinsCollected += 1;
        }

        public void invokeAnimation(int param, bool value)
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

    }
}
