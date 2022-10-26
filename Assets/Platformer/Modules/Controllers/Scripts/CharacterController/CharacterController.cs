using JuiceKit;
using System;
using System.Collections;
using System.Collections.Generic;
using Template.Elements;
using UnityEngine;

namespace Template.Controllers
{
    public class CharacterController : Controller
    {
        [SerializeField]
        private CharacterElement character;

        [SerializeField]
        private GameObject popup;
        private void Update()
        {
            if (!character.isDead & !popup.activeSelf)
            {
                character.JumpPlayer(Input.GetButtonDown("Jump"));
            }

            character.DiePlayer();
        }

        private void FixedUpdate()
        {
            if (!character.isDead & !popup.activeSelf)
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

        public void CharacterFreezeMove() 
        {
            character.FreezePlayer();
        }

        public void CharacterUnfreezeMove()
        {
            character.FreezePlayer();
        }
    }
}
