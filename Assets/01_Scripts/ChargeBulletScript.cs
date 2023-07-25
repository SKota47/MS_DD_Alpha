using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBulletScript : MonoBehaviour
{
    private float _chargeBulletDamage;
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;
    void Start()
    {
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _chargeBulletDamage = _playerMoveScripts._chargeBulletDamage;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01") || collision.gameObject.CompareTag("MiniBoss") || collision.gameObject.CompareTag("LastBoss") || collision.gameObject.CompareTag("Enemy02"))
        {
            EnemyHPScript _es = collision.GetComponent<EnemyHPScript>();
            _es._damage = _chargeBulletDamage;
            Destroy(gameObject);
        }
    }
}
