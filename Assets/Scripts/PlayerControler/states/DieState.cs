using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieState : State
{  
    public override void Enter(Character character)
    {
        character.animator.SetTrigger("isDying");
    }
}
