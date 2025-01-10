using System.Collections.Generic;
using UnityEngine;

public class SpwnManeger : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpwnPoints;
    private List<GameObject> usedPoint=new List<GameObject>(); 
    [SerializeField] private GameObject fishPrefab;

    private void Start()
    {
        Spwn();
    }


    private void Spwn()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject Point = SpwnPoints[Random.Range(0, SpwnPoints.Count)];
            Instantiate(fishPrefab, Point.transform.position, Quaternion.identity);
            usedPoint.Add(Point);
            SpwnPoints.Remove(Point);
        }
        SpwnPoints.AddRange(usedPoint);
        usedPoint.Clear();
    }
}
