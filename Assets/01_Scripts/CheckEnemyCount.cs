using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �c�G�̊m�F
/// </summary>
public class CheckEnemyCount : MonoBehaviour
{
    GameObject[] _enemyObjects;
    GameObject[] _flyEnemyObjects;
    public int _enemyNum;
    public int _enemyNumMax;    //�񕜗ʗp
    private int _regainNum = 4;     //�񕜗ʂǂ̂��炢��

    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;
    public GameObject _gate;
    private bool _isRegain = true;

    void Start()
    {
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _enemyObjects = GameObject.FindGameObjectsWithTag("Enemy01");
        _enemyNumMax = _enemyObjects.Length;
    }

    void Update()
    {
        _enemyObjects = GameObject.FindGameObjectsWithTag("Enemy01");
        // _flyEnemyObjects = GameObject.FindGameObjectsWithTag("Enemy02");
        _enemyNum = _enemyObjects.Length /*+ _flyEnemyObjects.Length*/;
        if (_enemyNum <= 0)
        {
            if (_isRegain)
            {
                _playerMoveScripts._regainBySystem = _enemyNumMax * _regainNum;
                _isRegain = false;
            }
            _gate.SetActive(true);
        }
        else
        {
            _gate.SetActive(false);
        }
    }
}
