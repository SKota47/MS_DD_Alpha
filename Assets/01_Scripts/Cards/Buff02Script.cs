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
        _description = "RangeATK\n+1\n-5HP";
    }

    // Update is called once per frame
    void Update()
    {
        Selection();
        _descHpReduce = (int)5;
        _preBulletDamage = (int)1;
        // _displayPreHpResuce = ((int)_playerScript._currentHP - _preHpReduce) - _descHpReduce;
        DisplayDescription();
    }
}