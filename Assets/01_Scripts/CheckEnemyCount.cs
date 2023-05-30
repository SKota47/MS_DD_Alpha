using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyCount : MonoBehaviour
{
    GameObject[] _enemyObjects;
    GameObject[] _flyEnemyObjects;
    public int _enemyNum;
    public GameObject _gate;
    void Start()
    {

    }

    void Update()
    {
        _enemyObjects = GameObject.FindGameObjectsWithTag("Enemy01");
        // _flyEnemyObjects = GameObject.FindGameObjectsWithTag("Enemy02");
        _enemyNum = _enemyObjects.Length /*+ _flyEnemyObjects.Length*/;
        if (_enemyNum <= 0)
        {
            _gate.SetActive(true);
        }
        else
        {
            _gate.SetActive(false);
        }
    }
}
