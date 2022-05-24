using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Character character = collision.rigidbody.GetComponent<Character>();
        if (character != null)
        {
            character.outOfBounds = true;
        }
    }

}
