using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateMachine
{ 
    private Character character;
   
    public StateMachine(Character character)
    {
        this.character = character;
        
    }

    public void InitializeState(State state)
    {
        character.InitializeState(state);
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
        return character.CheckIsGrounded(character.boxCollider2D);
    }

}

