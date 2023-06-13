using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buff01Script : NumBuffInherit
{

#if UNITY_EDITOR
    [CustomEditor(typeof(NumBuffInherit))]
#endif

    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _description = "ATK\n+2\n-5HP";
    }

    // Update is called once per frame
    void Update()
    {
        Selection();
        _descHpReduce = (int)5;
        _preAttackDamage = 2;
        //_displayPreHpResuce = ((int)_playerScript._currentHP - _preHpReduce) / 20;
        DisplayDescription();
    }
}