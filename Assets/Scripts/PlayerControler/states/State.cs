using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void HandleInput(Character character);

    public abstract void LogicUpdate(Character character);

    public abstract void UpdateState(Character character);

    public abstract void PhysicsUpdateState(Character character);
}
