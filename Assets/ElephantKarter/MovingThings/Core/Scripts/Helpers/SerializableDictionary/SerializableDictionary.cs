using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CoreDomain.Scripts.Utils.DebugUtils;
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
    public abstract class SerializableDictionaryBase<TKey, TValue, TValueStorage> : SerializableDictionaryBase, IDictionary<TKey, TValue>, IDictionary, ISerializationCallbackReceiver, IDeserializationCallback, ISerializable
    {
        public SerializableDictionaryBase()
        {
            m_dict = new Dictionary<TKey, TValue>();
        }
        public SerializableDictionaryBase(IDictionary<TKey, TValue> dict)
        {
            m_dict = new Dictionary<TKey, TValue>(dict);
        }
        Dictionary<TKey, TValue> m_dict;
        [SerializeField]
        TKey[] m_keys;
        [SerializeField]
        TValueStorage[] m_values;

        #region ISerializationCallbackReceiver
        public void OnBeforeSerialize()
        {
            Debug.Log(@$"OnBeforeSerialize - STARTED
m_dict: {m_dict}
m_values: {m_values}
m_keys: {m_keys}");
            var n = m_dict.Count;
            m_keys = new TKey[n];
            m_values = new TValueStorage[n];

            var i = 0;
            foreach (var kvp in m_dict)
            {
                m_keys[i] = kvp.Key;
                SetValue(m_values, i, kvp.Value);
                i++;
            }

            Debug.Log(@$"OnBeforeSerialize - ENDED
m_dict: {DebugUtils.DictionaryToString(m_dict)}
m_keys: {DebugUtils.CollectionToString(m_keys)}
m_values: {DebugUtils.CollectionToString(m_values)}
            ");
        }
        public void OnAfterDeserialize()
        {
            Debug.Log(@$"OnAfterDeserialize - STARTED
m_dict: {m_dict}
m_values: {m_values}
m_keys: {m_keys}");
            if (m_keys != null && m_values != null && m_keys.Length == m_values.Length)
            {
                m_dict.Clear();
                int n = m_keys.Length;
                for (int i = 0; i < n; i++)
                {
                    m_dict[m_keys[i]] = GetValue(m_values, i);
                }
            }
            Debug.Log(@$"OnAfterDeserialize - ENDED
m_dict: {m_dict}
m_values: {m_values}
m_keys: {m_keys}");
        }

        protected abstract void SetValue(TValueStorage[] storage, int i, TValue value);
        protected abstract TValue GetValue(TValueStorage[] storage, int i);

        #endregion

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

        #region ISerializable

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ((ISerializable)m_dict).GetObjectData(info, context);
        }
        protected SerializableDictionaryBase(SerializationInfo info, StreamingContext context)
        {
            m_dict = new Dictionary<TKey, TValue>(info, context);
        }

        #endregion

        #region IDeserializationCallback

        public void OnDeserialization(object sender)
        {
            ((IDeserializationCallback)m_dict).OnDeserialization(sender);
        }

        #endregion
    }

    public static class SerializableDictionary
    {
        [Serializable]
        public class Storage<T> : SerializableDictionaryBase.Storage
        {
            [SerializeReference]
            public T data;
        }
    }
    [Serializable]
    public class SerializableDictionary<TKey, TValue, TValueStorage> : SerializableDictionaryBase<TKey, TValue, TValueStorage> where TValueStorage : SerializableDictionary.Storage<TValue>, new()
    {
        public SerializableDictionary() { }
        public SerializableDictionary(IDictionary<TKey, TValue> dict) : base(dict) { }
        protected SerializableDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        protected override void SetValue(TValueStorage[] storage, int i, TValue value)
        {
            storage[i] = new TValueStorage();
            Debug.Log(storage[i]);
            storage[i].data = value;
        }
        protected override TValue GetValue(TValueStorage[] storage, int i)
        {
            return storage[i].data;
        }
    }
}