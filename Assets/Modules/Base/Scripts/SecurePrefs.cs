using System.Security.Cryptography;
using System.Text;
using JuiceKit;
using UnityEngine;

namespace Template
{
    public class SecurePrefs : Singleton<SecurePrefs>, IPreferences
    {
        string appKey;

        public void SetAppKey(string _appKey)
        {
            appKey = _appKey;
        }

        public int GetInt(string _key)
        {
            int _value = PlayerPrefs.GetInt(Md5(_key));
            if (!CheckValue(_key, _value.ToString()))
                _value = 0;

            return _value;
        }

        public void SetInt(string _key, int _value)
        {
            PlayerPrefs.SetInt(Md5(_key), _value);
            SetMd5Value(_key, _value.ToString());
        }

        public long GetLong(string _key)
        {
            string _valueStr = GetString(_key);
            long _value = long.Parse(_valueStr);

            return _value;
        }

        public void SetLong(string _key, long _value)
        {
            SetString(_key, _value.ToString());
        }

        public float GetFloat(string _key)
        {
            float _value = PlayerPrefs.GetFloat(Md5(_key));
            if (!CheckValue(_key, _value.ToString()))
                _value = 0;

            return _value;
        }

        public void SetFloat(string _key, float _value)
        {
            PlayerPrefs.SetFloat(Md5(_key), _value);
            SetMd5Value(_key, _value.ToString());
        }

        public bool GetBool(string _key)
        {
            int _intValue = PlayerPrefs.GetInt(Md5(_key));
            if (!CheckValue(_key, _intValue.ToString()))
                _intValue = 0;

            bool _value = _intValue == 1;
            return _value;
        }

        public void SetBool(string _key, bool _value)
        {
            int _intValue = _value ? 1 : 0;
            PlayerPrefs.SetInt(Md5(_key), _intValue);
            SetMd5Value(_key, _intValue.ToString());
        }

        public string GetString(string _key)
        {
            string _value = PlayerPrefs.GetString(Md5(_key));
            if (!CheckValue(_key, _value))
                _value = "";

            return _value;
        }

        public void SetString(string _key, string _value)
        {
            PlayerPrefs.SetString(Md5(_key), _value);
            SetMd5Value(_key, _value);
        }

        public string GetText(string _key)
        {
            string _text = null;

            if (FilesUtil.IsFileExist(_key))
            {
                _text = FilesUtil.ReadText(_key);
                if (!CheckValue(_key, _text))
                    _text = string.Empty;
            }
            else
                _text = string.Empty;

            return _text;
        }

        public void SaveText(string _key, string _value)
        {
            FilesUtil.SaveText(_key, _value);
            SetMd5Value(_key, _value);

            PlayerPrefs.Save();
        }

        public T GetObj<T>(string _key)
        {
            string _dataStr = GetText(_key);
            var _obj = JsonUtility.FromJson<T>(_dataStr);

            return _obj;
        }

        public void SaveObj(string _key, object _value)
        {
            bool _isPretty = false;
#if UNITY_EDITOR
            _isPretty = true;
#endif

            var _text = JsonUtility.ToJson(_value, _isPretty);
            SaveText(_key, _text);
        }

        public bool HasKey(string _key)
        {
            bool _hasKey = PlayerPrefs.HasKey(Md5(_key));
            if (!_hasKey)
                _hasKey = FilesUtil.IsFileExist(_key);

            return _hasKey;
        }

        public void RemoveKey(string _key)
        {
            if (FilesUtil.IsFileExist(_key))
                FilesUtil.DeleteFile(_key);

            PlayerPrefs.DeleteKey(Md5(_key));
            PlayerPrefs.DeleteKey(Md5(ConvertKeyForMd5Value(_key)));

            PlayerPrefs.Save();
        }

        public void SaveData()
        {
            PlayerPrefs.Save();
        }

        public void ClearData()
        {
            FilesUtil.DeleteAllFiles();
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        void SetMd5Value(string _key, string _value)
        {
            _key = Md5(ConvertKeyForMd5Value(_key));
            _value = Md5(_value);

            PlayerPrefs.SetString(_key, _value);
        }

        bool CheckValue(string _key, string _value)
        {
            Log.Message(Name, "Check value: key " + _key + " value " + _value);

            bool _isCheck = false;

            _key = Md5(ConvertKeyForMd5Value(_key));
            _value = Md5(_value);

            _isCheck = _value == PlayerPrefs.GetString(_key);

            if (PlayerPrefs.HasKey(_key) &&
                !_isCheck)
                Log.MessageWarning(Name, "Data was hacked!");

            return _isCheck;
        }

        string ConvertKeyForMd5Value(string _key)
        {
            _key = _key + "EF5nsh";
            return _key;
        }

        string Md5(string _originalStr)
        {
            Assert.IsNotNull(appKey, () => $"App key must be assigned!");

            UTF8Encoding _encoding = new UTF8Encoding();
            _originalStr = _originalStr + appKey;
            byte[] _bytes = _encoding.GetBytes(_originalStr);

            MD5CryptoServiceProvider _md5Service = new MD5CryptoServiceProvider();
            byte[] _hashBytes = _md5Service.ComputeHash(_bytes);

            StringBuilder _strBuilder = new StringBuilder();

            for (int i = 0; i < _hashBytes.Length; i++)
            {
                _strBuilder.Append(System.Convert.ToString(_hashBytes[i], 16).PadLeft(2, '0'));
            }

            string _hashStr = _strBuilder.ToString().PadLeft(32, '0');

            return _hashStr;
        }
    }
}