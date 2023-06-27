using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private float _currentHP;
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;


    // Start is called before the first frame update
    void Start()
    {
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _currentHP = _playerMoveScripts._currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMoveScripts _es = collision.GetComponent<PlayerMoveScripts>();
            _es._currentHP -= 5;
            Destroy(gameObject);
        }
    }
}
