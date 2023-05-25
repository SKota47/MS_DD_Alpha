using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buff03Script : NumBuffInherit
{

#if UNITY_EDITOR
    [CustomEditor(typeof(NumBuffInherit))]
#endif

    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _inputKeyCord = (int)KeyCode.Alpha3;
        _description = "BulletPower++\n-20HP";
    }

    // Update is called once per frame
    void Update()
    {
        Selection();
        _descHpReduce = (int)20;
        DisplayDescription();
    }
}