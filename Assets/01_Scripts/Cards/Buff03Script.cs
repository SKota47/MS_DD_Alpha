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
        _description = "SPD\n+2\n-5HP";
    }

    // Update is called once per frame
    void Update()
    {
        if (_startButtonScript._isClick)
        {
            Execute();
        }
        //Selection();
        _descHpReduce = (int)5;
        _prePlayerSpeed = (int)2;
        //_displayPreHpResuce = ((int)_playerScript._currentHP - _preHpReduce) - _descHpReduce;
        DisplayDescription();
    }
}