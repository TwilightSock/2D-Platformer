using JuiceKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Elements
{
    public class CollectableElement : Element
    {
        [SerializeField] private AudioSource collectItemSound;

        private void OnTriggerEnter2D(Collider2D _collider)
        {
            if (_collider.gameObject.CompareTag("Player"))
            {
                //AudioSource.PlayClipAtPoint(collectItemSound.clip, transform.position);
                //SetActive(false);
                GetComponent<SpriteRenderer>().enabled = false;
                collectItemSound.Play();
                _collider.GetComponent<CharacterElement>().OnCollectItem();
                Invoke("DestroyCoin", collectItemSound.clip.length) ;
                              
            }
        }

        void DestroyCoin() 
        {
            Destroy(gameObject);
        }
    }
}
