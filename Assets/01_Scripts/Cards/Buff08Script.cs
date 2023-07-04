using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buff08Script : NumBuffInherit
{

#if UNITY_EDITOR
    [CustomEditor(typeof(NumBuffInherit))]
#endif

    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _description = "RangeATK\n+4\n-15HP";
    }

    // Update is called once per frame
    void Update()
    {
        if (_startButtonScript._isClick)
        {
            Execute();
        }
        //Selection();
        _descHpReduce = (int)15;
        _preBulletDamage = (int)4;
        DisplayDescription();
    }
}