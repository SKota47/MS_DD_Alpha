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
        _description = "ATK\n+4\n-10HP";
    }

    // Update is called once per frame
    void Update()
    {
        Selection();
        _descHpReduce = (int)10;
        _preAttackDamage = (int)4;
        // _displayPreHpResuce = ((int)_playerScript._currentHP - _preHpReduce) / 25;
        DisplayDescription();
    }
}