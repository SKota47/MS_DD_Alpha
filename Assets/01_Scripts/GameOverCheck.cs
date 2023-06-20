using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;
    public GameObject _gameOverCanvas;

    void Start()
    {
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
    }

    void Update()
    {
        if (_playerMoveScripts._currentHP <= 0 && !_gameOverCanvas.activeSelf)
        {
            _gameOverCanvas.SetActive(true);
            _playerMoveScripts._isDead = true;
        }
    }
}