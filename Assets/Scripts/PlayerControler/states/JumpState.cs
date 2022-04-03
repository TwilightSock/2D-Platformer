using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class JumpState : State
{
    private bool grounded;
    private bool jump;
    public override void Enter(Character character)
    {
        grounded = false;
        jump = Input.GetButtonDown("Jump");
        character.JumpPlayer();
    }

    public override void LogicUpdate(Character character)
    {
        if (grounded)
        {
            character.animator.SetBool("isJumping", false);
            character.InitiaizeState(character.moveState);
        }
        
        else if (character.health == 0 || character.health < 0) 
        {
            character.InitiaizeState(character.dieState);
        }
    }

    public override void UpdateState(Character character)
    {
        if (character.rigidbody.velocity.y > 0)
        {
            Task task = new Task(async () =>
            {
                await Task.Delay(40);
                CheckGround(character);
            });
            task.Start();
        }
        else
        {
            CheckGround(character);
        }

    }

    private void CheckGround(Character character)
    {
        grounded = character.CheckIsGrouded(character.boxCollider2D);
    }
}
