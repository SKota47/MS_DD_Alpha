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

        _description = "AttackDamage*2\n-50%HP";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isSelected)
        {
            Selected();
            _panelImage.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            isSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && isSelected)
        {
            UnSelected();
            _panelImage.color = new Color(1.0f, 1.0f, 0.0f, 0.5f);
            isSelected = !isSelected;
        }

        _descHpReduce = (int)_playerScript._currentHP / 2;
        DisplayDescription();
    }
}