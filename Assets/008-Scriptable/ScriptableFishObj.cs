using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/FishList")]
public class ScriptableFishObj : ScriptableObject
{
    public List<FishStates> FishList;
}

[System.Serializable]
public struct FishStates
{
    public string name;
    public float Size;
    public int max_Size;
    public int min_Size;
    public float strength;
    public float battle_Frequently;
    public float move_Frequently;
}
