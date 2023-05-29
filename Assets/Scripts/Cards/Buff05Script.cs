using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buff05Script : NumBuffInherit
{

#if UNITY_EDITOR
    [CustomEditor(typeof(NumBuffInherit))]
#endif

    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _description = "‹­‰»‚T\n-2HP";
    }

    // Update is called once per frame
    void Update()
    {
        Selection();
        _descHpReduce = (int)2;
        DisplayDescription();
    }
}