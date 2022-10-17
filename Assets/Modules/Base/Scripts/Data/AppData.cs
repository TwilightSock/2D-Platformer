using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template.Data
{
    [Serializable]
    public class AppData
    {
        [SerializeField]
        string v;
        [SerializeField]
        int vc;
        [SerializeField]
        UserData userData;

        public string Version { get => v; set => v = value; }
        public int VersionCode { get => vc; set => vc = value; }
        public UserData UserData { get => userData; set => userData = value; }
    }

    [Serializable]
    public class UserData
    {
        
    }
}
