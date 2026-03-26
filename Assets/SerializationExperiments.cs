using CoreDomain.Scripts.Helpers.SerializableDictionary;
using UnityEngine;

public class SerializationExperiments : MonoBehaviour
{
    [SerializeField] SerializableDictionaryBase<string, int> dict;

    [ContextMenu("Add Random Entry")]
    void AddEntry()
    {
        int k = Random.Range(0, 100);
        dict[k.ToString()] = k;
    }
}
