using System.Collections;
using System.Collections.Generic;
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
            character.animator.SetBool("IsJumpuing", false);
            character.InitiaizeState(character.moveState);
        }
        
        else if (character.health == 0 || character.health < 0) 
        {
            character.InitiaizeState(character.dieState);
        }
    }

    public override void PhysicsUpdateState(Character character)
    {
        grounded = character.CheckIsGrouded(character.boxCollider2D);
    }

}
