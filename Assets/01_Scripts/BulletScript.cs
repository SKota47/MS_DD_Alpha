using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//弾自体の管理
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

    /// <summary>
    /// 触れた際に敵だった場合敵に弾のダメージを反映させる
    /// </summary>
    /// <param name="collision">当たったモノ</param>
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
