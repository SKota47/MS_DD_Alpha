using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffExecuteScript : MonoBehaviour
{
    public bool _isClick = false;
    void Start()
    {

    }

    void Update()
    {
        Debug.Log(_isClick);
    }

    public void OnClick()
    {
        _isClick = true;
        Time.timeScale = 1;
    }
}