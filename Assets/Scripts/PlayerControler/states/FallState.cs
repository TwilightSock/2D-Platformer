using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : State
{
    private bool fall;  
    public override void LogicUpdate(Character character)
    {
        if (character.rigidbody.velocity.y < -.1f)
        {
            fall = true;
        }
        else if (character.rigidbody.velocity.y >= 0f)
        {
            fall = false;
            character.currentState = character.moveState;
        }
    }
}
