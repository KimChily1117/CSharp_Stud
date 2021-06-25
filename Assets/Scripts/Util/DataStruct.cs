using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStruct : MonoBehaviour
{
    public List<Dictionary<string, int>> valuePairs;

    private void Awake()
    {
        valuePairs = new List<Dictionary<string, int>>();
    }
    private void Update()
    {
        
    }

}
