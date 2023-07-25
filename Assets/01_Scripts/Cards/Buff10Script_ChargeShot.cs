using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Buff10Script_ChargeShot : NumBuffInherit
{

#if UNITY_EDITOR
    [CustomEditor(typeof(NumBuffInherit))]
#endif

    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _description = "チャージショット\n\n-10%HP";
    }

    // Update is called once per frame
    void Update()
    {
        if (_startButtonScript._isClick)
        {
            if (isSelected)
            {
                _bulletShotScript._isChargeShot = true;
            }
            Execute();
        }
        //Selection();
        _displayPreHpResuce = ((int)_playerScript._currentHP - _preHpReduce) / 10;
        _preAttackDamage = 8;
        DisplayDescription();
    }
}