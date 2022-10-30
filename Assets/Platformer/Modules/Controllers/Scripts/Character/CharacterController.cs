using JuiceKit;
using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Elements;
using UnityEngine;

namespace Platformer.Controllers
{
    public class CharacterController : Controller
    {
        [SerializeField]
        private CharacterElement character;
  
        private void Update()
        {
            if (!character.isDead)
            {
                character.JumpPlayer(Input.GetButtonDown("Jump"));
            }

            character.DiePlayer();
        }

        private void FixedUpdate()
        {
            if (!character.isDead )
            {
                character.MovePlayer(Input.GetAxis("Horizontal"));
            }
        }


        public void CharacterOnDeathAction(Action action)
        {
            character.onCharacterDeath = action;
        }


        public int CharacterCoinsCollected 
        {
            get 
            { 
                return character.coinsCollected; 
            } 
            
        }

    }
}
