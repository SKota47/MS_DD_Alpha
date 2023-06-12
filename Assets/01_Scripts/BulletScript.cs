using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01"))
        {
            EnemyHPScript _es = collision.GetComponent<EnemyHPScript>();
            _es._damage = _bulletDamage;
            Destroy(gameObject);
        }
    }
}
