using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetCharacter : MonoBehaviour
{  
    public void ResetThisCharacter()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
