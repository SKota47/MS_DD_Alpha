using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buff02Script : NumBuffInherit
{

#if UNITY_EDITOR
    [CustomEditor(typeof(NumBuffInherit))]
#endif

    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _description = "������\n�U����\n+3\n-5HP";
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
        _preBulletDamage = (int)3;
        // _displayPreHpResuce = ((int)_playerScript._currentHP - _preHpReduce) - _descHpReduce;
        DisplayDescription();
    }
}