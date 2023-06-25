using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 残敵の確認
/// </summary>
public class CheckEnemyCount : MonoBehaviour
{
    GameObject[] _enemyObjects;
    GameObject[] _flyEnemyObjects;
    GameObject[] _bossObjects;
    public int _enemyNum;
    public int _bossNum;
    public int _enemyNumMax;    //回復量用
    private int _regainNum = 4;     //回復量どのくらいか

    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;
    public GameObject _gate;
    private bool _isRegain = true;

    void Start()
    {
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _enemyObjects = GameObject.FindGameObjectsWithTag("Enemy01");
        if (SceneManager.GetActiveScene().name == "Stage03_Boss")
        {
            _bossObjects = GameObject.FindGameObjectsWithTag("MiniBoss");
        }
        _enemyNumMax = _enemyObjects.Length;
    }

    void Update()
    {
        _enemyObjects = GameObject.FindGameObjectsWithTag("Enemy01");
        if (SceneManager.GetActiveScene().name == "Stage03_Boss")
        {
            _bossObjects = GameObject.FindGameObjectsWithTag("MiniBoss");
        }
        _enemyNum = _enemyObjects.Length;
        if (_bossObjects != null)
        {
            _bossNum = _bossObjects.Length;
        }

        if (_enemyNum <= 0 && _bossNum <= 0)
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
