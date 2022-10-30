using JuiceKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Platformer.Elements
{
    public class TrapElement : Element
    {
        public int trapDamage { get; set; } = 1;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            CharacterElement character = collision.rigidbody.GetComponent<CharacterElement>();
            if (character != null)
            {
                character.DoDamage(trapDamage);
            }
        }
    }
}
