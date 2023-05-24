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

        _description = "BulletPower++\n-20HP";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isSelected)
        {
            Selected();
            _panelImage.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            isSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && isSelected)
        {
            UnSelected();
            _panelImage.color = new Color(1.0f, 1.0f, 0.0f, 0.5f);
            isSelected = !isSelected;
        }

        _descHpReduce = (int)20;
        DisplayDescription();
    }
}