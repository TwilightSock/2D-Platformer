using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private bool grounded;
    private bool jump;
    public override void HandleInput(Character character)
    {   
        grounded = character.CheckIsGrouded(character.boxCollider2D);
        jump = Input.GetButtonDown("Jump");
    }

    public override void LogicUpdate(Character character)
    {
        if (grounded)
        {
            character.currentState = character.moveState;
        }
        
        else if (character.health == 0 || character.health < 0) 
        {
            character.currentState = character.dieState;
        }
    }
    public override void UpdateState(Character character)
    {
        if (jump)
        {
            character.JumpPlayer(grounded);
        }

    }

}
