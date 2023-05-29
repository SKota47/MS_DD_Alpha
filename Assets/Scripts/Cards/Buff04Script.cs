using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buff04Script : NumBuffInherit
{

#if UNITY_EDITOR
    [CustomEditor(typeof(NumBuffInherit))]
#endif

    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _description = "‹­‰»‚S\n-4%HP";
    }

    // Update is called once per frame
    void Update()
    {
        Selection();
        _descHpReduce = (int)_playerScript._currentHP / 25;
        DisplayDescription();
    }
}