using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "ScriptableObjects/SeedConfig", order = 1)]
public class SeedScriptableObject : ScriptableObject
{
    public GameObject Prefab;
    public int itemID;
}