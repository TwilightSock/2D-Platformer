using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateMachine stateMachine;
    protected Character character;
    public State(StateMachine stateMachine,Character character)
    {
        this.stateMachine = stateMachine;
        this.character = character;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update() 
    {
    
    }
    public virtual void Jump() 
    {
        
    }
    public virtual void Move() 
    {
    
    }

}
