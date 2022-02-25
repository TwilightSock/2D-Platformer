using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private bool grounded;
    public override void HandleInput(Character character)
    {
        grounded = character.CheckIsGrouded(character.boxCollider2D);
    }

    public override void LogicUpdate(Character character)
    {
        if (grounded) 
        {
            character.currentState = character.moveState;
        }
    }
    public override void UpdateState(Character character)
    {
        character.jumpPlayer();

        if (character.CheckIsGrouded(character.boxCollider2D)) 
        {
            character.currentState = character.moveState;
        }
    }

    public override void PhysicsUpdateState(Character character)
    {
        
    }

}
