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
        _inputKeyCord = (int)KeyCode.Alpha1;
        _description = "AttackDamage*2\n-50%HP";
    }

    // Update is called once per frame
    void Update()
    {
        Selection();
        _descHpReduce = (int)_playerScript._currentHP / 2;
        DisplayDescription();
    }
}