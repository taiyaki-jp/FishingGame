using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField]private ScriptableFishObj objs;


    public FishStates thisStates;

    private void Start()
    {
        thisStates = objs.FishList[Random.Range(0, objs.FishList.Count)];

        thisStates.Size=Random.Range(thisStates.min_Size, thisStates.max_Size);

        Debug.Log(thisStates.name);
    }
}
