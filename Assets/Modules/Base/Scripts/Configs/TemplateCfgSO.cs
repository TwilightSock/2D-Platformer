using System;
using System.Collections;
using System.Collections.Generic;
using JuiceKit;
using UnityEngine;

namespace Template.Configs.Test
{
    [CreateAssetMenu(fileName = "TemplateCfg", menuName = "Template/Configs/TemplateCfg")]
    public class TemplateCfgSO : BaseConfigSO<TemplateCfg>
    {
    }

    [Serializable]
    public class TemplateCfg : BaseConfig
    {
        [SerializeField]
        int aInt;
        [SerializeField]
        float bFloat;
        [SerializeField]
        bool cBool;
        [SerializeField]
        string dStr;
        [SerializeField]
        Vector2 eVector;
        [SerializeField]
        List<int> aIntsList;
        [SerializeField]
        List<Vector3> fVectorsList;
        [SerializeField]
        CustomCfg customCfg;
        [SerializeField]
        List<CustomCfg> customCfgsList;
        
        public int AInt { get => aInt; }
        public float BFloat { get => bFloat; }
        public bool CBool { get => cBool; }
        public string DStr { get => dStr; }
        public Vector2 EVector { get => eVector; }
        public List<int> AIntsList { get => aIntsList; }
        public List<Vector3> FVectorsList { get => fVectorsList; }
        public CustomCfg CustomCfg { get => customCfg; }
        public List<CustomCfg> CustomCfgsList { get => customCfgsList; }
    }

    [Serializable]
    public class CustomCfg : BaseConfig
    {
        [SerializeField]
        int aInt;
        [SerializeField]
        float bFloat;
        [SerializeField]
        Custom2Cfg c2Cfg;
        [SerializeField]
        List<Custom2Cfg> c2Cfgs;
        [SerializeField]
        List<string> dStrs;
        [SerializeField]
        string jStr;
        
        public int AInt { get => aInt; }
        public float BFloat { get => bFloat; }
        public Custom2Cfg C2Cfg { get => c2Cfg; }
        public List<Custom2Cfg> C2Cfgs { get => c2Cfgs; }
        public List<string> DStrs { get => dStrs; }
        public string JStr { get => jStr; }
    }

    [Serializable]
    public class Custom2Cfg : BaseConfig
    {
        [SerializeField]
        string dStr;
        [SerializeField]
        Vector2 eVector;
        [SerializeField]
        List<int> aIntsList;
        [SerializeField]
        List<Vector3> fVectorsList;
        
        public string DStr { get => dStr; }
        public Vector2 EVector { get => eVector; }
        public List<int> AIntsList { get => aIntsList; }
        public List<Vector3> FVectorsList { get => fVectorsList; }
    }
}