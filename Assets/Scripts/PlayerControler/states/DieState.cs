using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieState : State
{
    public DieState(StateMachine stateMachine, Character character) : base(stateMachine, character)
    {
    }
    
    public override void Update()
    {
        character.animator.SetTrigger("isDying");
    }

}
