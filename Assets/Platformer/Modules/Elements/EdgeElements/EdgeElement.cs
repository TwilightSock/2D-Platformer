using JuiceKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Platformer.Elements
{
    public class EdgeElement : Element
    {
        public void OnCollisionEnter2D(Collision2D collision)
        {
            CharacterElement character = collision.rigidbody.GetComponent<CharacterElement>();
            if (character != null)
            {
                character.OnFall();
            }
        }
    }
}
