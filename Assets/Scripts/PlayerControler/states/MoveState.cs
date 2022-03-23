using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private float speed;

    private float horizontalInput;
    private bool jump;

    public override void HandleInput(Character character)
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
    }

    public override void LogicUpdate(Character character)
    {
        if (jump && character.CheckIsGrouded(character.boxCollider2D))
        {
            character.InitiaizeState(character.jumpState);
        }
        else if (character.health == 0 || character.health < 0)
        {
            character.InitiaizeState(character.dieState);
        }
        
    }

    public override void PhysicsUpdateState(Character character)
    {
        character.MovePlayer(horizontalInput);
    }

}
