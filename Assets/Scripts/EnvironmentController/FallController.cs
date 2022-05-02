using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour
{   
    [SerializeField]
    private Character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (character.transform.position.y < -3.5)
        {
            character.health -= character.health;
        }

    }
}
