using System;
using System.Linq.Expressions;
using CoreDomain.Scripts.Helpers.SerializableDictionary;
using UnityEngine;

public class SerializationExperiments : MonoBehaviour
{
    [SerializeField] SerializableDictionary<string, IData, SerializableDictionary.Storage<IData>> dict;

    [ContextMenu("Add Random Entry")]
    void AddEntry()
    {
        int k = UnityEngine.Random.Range(0, 100);
        dict[k.ToString()] = new IntData(k);
    }

    private interface IData
    {
        public int GetData();
    }
    [Serializable]
    private class IntData : IData
    {
        public IntData(int data)
        {
            _data = data;
        }
        int _data;
        public int GetData()
        {
            return _data;
        }
        public override string ToString()
        {
            return _data.ToString();
        }
    }
}
