using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField] private AudioSource collectItemSound;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectItemSound.clip,transform.position);
            collider.GetComponent<Character>().OnCollectItem();
            Destroy(gameObject);

        }
    }
}
