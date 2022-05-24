using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public int trapDamage { get; set; } = 1;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Character character = collision.rigidbody.GetComponent<Character>();
        if (character != null) 
        {
            character.DoDamage(trapDamage);
        }
    }
}
