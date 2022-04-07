using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class JumpState : State
{
    private bool grounded;

    public JumpState(StateMachine stateMachine, Character character) : base(stateMachine, character)
    {

    }

    public override void Enter()
    {
        grounded = false;
        stateMachine.InputJump();
    }

    public override void Update()
    {
        
        if (character.rigidbody.velocity.y > 0)
        {
            Task task = new Task(async () =>
            {
                await Task.Delay(30);
                grounded = stateMachine.CheckGround();
            });
            task.Start();
        }
        else
        {
            grounded = stateMachine.CheckGround();
        }

        if (character.health == 0 || character.health < 0) 
        {
            stateMachine.InitializeState(character.dieState);
        }

    }

    public override void Move()
    {
        if (grounded)
        {
             character.animator.SetBool("isJumping", false);
            stateMachine.InitializeState(character.moveState);
        }
    }

   
}
