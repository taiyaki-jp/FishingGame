using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField]private ScriptableFishObj _objs;


    public FishStates thisStates;

    private void Start()
    {
        thisStates = _objs.FishList[Random.Range(0, _objs.FishList.Count)];

        thisStates.size=Random.Range(thisStates.min_Size, thisStates.max_Size);

        Debug.Log(thisStates.name);
    }
}
