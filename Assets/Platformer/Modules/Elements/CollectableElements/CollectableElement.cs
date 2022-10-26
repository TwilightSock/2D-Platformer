using JuiceKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template.Elements
{
    public class CollectableElement : Element
    {
        [SerializeField] private AudioSource collectItemSound;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                AudioSource.PlayClipAtPoint(collectItemSound.clip, transform.position);
                collider.GetComponent<CharacterElement>().OnCollectItem();
                Destroy(gameObject);

            }
        }
    }
}
