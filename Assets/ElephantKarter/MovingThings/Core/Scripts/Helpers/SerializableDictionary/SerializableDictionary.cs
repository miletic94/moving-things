using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace CoreDomain.Scripts.Helpers.SerializableDictionary
{
    public abstract class SerializableDictionaryBase
    {
        public abstract class Storage { }

        protected class Dictionary<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue>
        {
            public Dictionary() { }
            public Dictionary(IDictionary<TKey, TValue> dict) : base(dict) { }
            public Dictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }
    }

    [Serializable]
    public class SerializableDictionary<TKey, TValue>
    {
        Dictionary<TKey, TValue> m_dict;
        [SerializeField]
        TKey[] m_keys;
        [SerializeField]
        TValue[] m_values;
    }
}