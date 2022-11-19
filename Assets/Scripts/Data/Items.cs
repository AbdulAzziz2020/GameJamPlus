using UnityEngine;

[CreateAssetMenu]
public class Items : ScriptableObject
{
    public string itemName;
    public int itemWeight;
    
    public GameObject prefab;
}