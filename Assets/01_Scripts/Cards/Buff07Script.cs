using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buff07Script : NumBuffInherit
{

#if UNITY_EDITOR
    [CustomEditor(typeof(NumBuffInherit))]
#endif

    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _description = "ãﬂê⁄\nçUåÇóÕ\n+10\n-20HP";
    }

    // Update is called once per frame
    void Update()
    {
        if (_startButtonScript._isClick)
        {
            Execute();
        }
        //Selection();
        _descHpReduce = (int)20;
        _preAttackDamage = 10;
        DisplayDescription();
    }
}