using JuiceKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template.Elements
{
    public class CameraElement : Element
    {
        [SerializeField]
        private Transform moveTo;

        private void LateUpdate()
        {
            transform.position = new Vector3(moveTo.position.x, transform.position.y, transform.position.z);
        }
    }
}
