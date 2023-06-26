using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buff09Script : NumBuffInherit
{

#if UNITY_EDITOR
    [CustomEditor(typeof(NumBuffInherit))]
#endif

    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _description = "ATK\n+8\n-20HP";
    }

    // Update is called once per frame
    void Update()
    {
        Selection();
        _descHpReduce = (int)10;
        DisplayDescription();
    }
}