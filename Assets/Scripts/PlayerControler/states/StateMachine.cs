using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{ 
    private Character character;
    public State moveState { get; private set; }
    public State jumpState { get; private set; }
    public State dieState { get; private set; }
    public StateMachine(Character character)
    {
        this.character = character;
        moveState = new MoveState(this,character);
        jumpState = new JumpState(this,character);
        dieState = new DieState(this,character);
    }

    public void InitiaizeState(State state)
    {
        character.currentState = state;
    }
    public void InputJump()
    {
        character.JumpPlayer();
    }

    public void InputMove()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
       character.MovePlayer(horizontalInput);
    }

    public bool CheckGround()
    {
        return character.CheckIsGrouded(character.boxCollider2D);
    }
}
