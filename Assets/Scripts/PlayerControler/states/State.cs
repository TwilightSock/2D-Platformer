using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{  
    public virtual void Enter(Character character) 
    {
    
    }
    public virtual void HandleInput(Character character) 
    {
        
    }
    public virtual void LogicUpdate(Character character) 
    {
    
    }
    public virtual void UpdateState(Character character)
    {

    }
    public virtual void PhysicsUpdateState(Character character) 
    {
    
    }
}
