using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(StateMachine stateMachine, Character character) : base(stateMachine,character)
    {

    }

    public override void Update()
    { 
        if (character.health == 0 || character.health < 0)
        {
            stateMachine.InitializeState(character.dieState);
        }

    }

    public override void Jump()
    {
        if (Input.GetButtonDown("Jump") && stateMachine.CheckGround())
        {
            stateMachine.InitializeState(character.jumpState);
        }

    }

    public override void Move()
    {
        stateMachine.InputMove();
    }

}
