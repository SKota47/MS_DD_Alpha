using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 残敵の確認
/// </summary>
public class CheckEnemyCount : MonoBehaviour
{
    GameObject[] _enemy01Objects;
    GameObject[] _enemy02Objects;
    GameObject[] _flyEnemyObjects;
    GameObject[] _bossObjects;
    GameObject[] _lastBossObjects;
    public int _enemyNum;
    public int _bossNum;
    public int _lastBossNum;
    public int _enemyNumMax;    //回復量用
    private int _regainNum = 4;     //回復量どのくらいか

    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;
    public GameObject _gate;
    public GameObject _closegate;
    private bool _isRegain = true;

    void Start()
    {
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _enemy01Objects = GameObject.FindGameObjectsWithTag("Enemy01");
        _enemy02Objects = GameObject.FindGameObjectsWithTag("Enemy02");
        if (SceneManager.GetActiveScene().name == "Stage03_Boss")
        {
            _bossObjects = GameObject.FindGameObjectsWithTag("MiniBoss");
        }
        if (SceneManager.GetActiveScene().name == "Stage07")
        {
            _lastBossObjects = GameObject.FindGameObjectsWithTag("LastBoss");
        }
        _enemyNumMax = _enemy01Objects.Length + _enemy02Objects.Length;
    }

    void Update()
    {
        _enemy01Objects = GameObject.FindGameObjectsWithTag("Enemy01");
        _enemy02Objects = GameObject.FindGameObjectsWithTag("Enemy02");
        if (SceneManager.GetActiveScene().name == "Stage03_Boss")
        {
            _bossObjects = GameObject.FindGameObjectsWithTag("MiniBoss");
        }
        if (SceneManager.GetActiveScene().name == "Stage07")
        {
            _lastBossObjects = GameObject.FindGameObjectsWithTag("LastBoss");
        }
        _enemyNum = _enemy01Objects.Length + _enemy02Objects.Length;
        if (_bossObjects != null)
        {
            _bossNum = _bossObjects.Length;
        }
        if (_lastBossObjects != null)
        {
            _lastBossNum = _lastBossObjects.Length;
        }

        if (_enemyNum <= 0 && _bossNum <= 0 && _lastBossNum <= 0)
        {
            if (_isRegain)
            {
                _playerMoveScripts._regainBySystem = _enemyNumMax * _regainNum;
                _isRegain = false;
            }
            _gate.SetActive(true);
            _closegate.SetActive(false);
            if (SceneManager.GetActiveScene().name == "Stage03_Boss")
            {
                if (_playerMoveScripts._maxHP == 100) _playerMoveScripts._maxHP = _playerMoveScripts._maxHP + 50;
                _playerMoveScripts._currentHP = _playerMoveScripts._maxHP;
            }
        }
        else
        {
            _gate.SetActive(false);
        }
    }
}
