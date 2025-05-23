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
    public float size;
    public int max_Size;
    public int min_Size;
    public float strength;
    public int battle_Frequently;//特殊行動頻度＝使わない？ 少ないほど頻度が多い
    public int move_Frequently;  //移動頻度 少ないほど頻度が多い
}
