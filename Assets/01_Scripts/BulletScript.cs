using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�e���̂�
public class BulletScript : MonoBehaviour
{
    private float _bulletDamage;
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;
    void Start()
    {
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _bulletDamage = _playerMoveScripts._bulletDamage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01") || collision.gameObject.CompareTag("MiniBoss") || collision.gameObject.CompareTag("LastBoss") || collision.gameObject.CompareTag("Enemy02"))
        {
            EnemyHPScript _es = collision.GetComponent<EnemyHPScript>();
            _es._damage = _bulletDamage;
            Destroy(gameObject);
        }
    }
}
