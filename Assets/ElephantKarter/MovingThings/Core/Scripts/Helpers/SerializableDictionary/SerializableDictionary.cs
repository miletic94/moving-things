using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CoreDomain.Scripts.Helpers.SerializableDictionary;
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
    public class SerializableDictionary<TKey, TValue> : SerializableDictionaryBase, IDictionary<TKey, TValue>, IDictionary
    {

        Dictionary<TKey, TValue> m_dict;
        [SerializeField]
        TKey[] m_keys;
        [SerializeField]
        TValue[] m_values;

        #region IDictionary<TKey, TValue> forwarding

        public TValue this[TKey key]
        {
            get { return ((IDictionary<TKey, TValue>)m_dict)[key]; }
            set { ((IDictionary<TKey, TValue>)m_dict)[key] = value; }
        }
        public ICollection<TKey> Keys { get { return ((IDictionary<TKey, TValue>)m_dict).Keys; } }
        public ICollection<TValue> Values { get { return ((IDictionary<TKey, TValue>)m_dict).Values; } }
        public int Count { get { return ((IDictionary<TKey, TValue>)m_dict).Count; } }
        public bool IsReadOnly { get { return ((IDictionary<TKey, TValue>)m_dict).IsReadOnly; } }

        public void Add(TKey key, TValue value)
        {
            // Casting: 
            // 1) In case protected class Dictionary<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue> overrides dictionary method, cast ensures that IDictionary method is directly called, bypassing override
            // 2) In case that m_dict changes Type and that Type doesn't impelement IDictionary it will throw InvalidCastException
            ((IDictionary<TKey, TValue>)m_dict).Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ((IDictionary<TKey, TValue>)m_dict).Add(item);
        }

        public bool ContainsKey(TKey key)
        {
            return ((IDictionary<TKey, TValue>)m_dict).ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            return ((IDictionary<TKey, TValue>)m_dict).Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return ((IDictionary<TKey, TValue>)m_dict).TryGetValue(key, out value);
        }

        public void Clear()
        {
            ((IDictionary<TKey, TValue>)m_dict).Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)m_dict).Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<TKey, TValue>)m_dict).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)m_dict).Remove(item);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)m_dict).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<TKey, TValue>)m_dict).GetEnumerator();
        }
        #endregion

        #region IDictionary

        public object this[object key]
        {
            get { return ((IDictionary)m_dict)[key]; }
            set { ((IDictionary)m_dict)[key] = value; }
        }
        public bool IsFixedSize { get { return ((IDictionary)m_dict).IsFixedSize; } }
        ICollection IDictionary.Keys { get { return ((IDictionary)m_dict).Keys; } }
        ICollection IDictionary.Values { get { return ((IDictionary)m_dict).Values; } }
        public bool IsSynchronized { get { return ((IDictionary)m_dict).IsSynchronized; } }
        public object SyncRoot { get { return ((IDictionary)m_dict).SyncRoot; } }

        public void Add(object key, object value)
        {
            ((IDictionary)m_dict).Add(key, value);
        }

        public bool Contains(object key)
        {
            return ((IDictionary)m_dict).Contains(key);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return ((IDictionary)m_dict).GetEnumerator();
        }

        public void Remove(object key)
        {
            ((IDictionary)m_dict).Remove(key);
        }

        public void CopyTo(Array array, int index)
        {
            ((IDictionary)m_dict).CopyTo(array, index);
        }

        #endregion
    }
}

public class Program
{
    public void Test()
    {
        var t = new SerializableDictionary<string, int>();

        t.Add("a", 1);
    }
}