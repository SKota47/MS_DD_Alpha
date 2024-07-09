using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤーの攻撃(攻撃時に出る当たり判定にアタッチ)
/// </summary>

public class PlayerAttackScript : MonoBehaviour
{
    [System.NonSerialized] public int _ATTACK_DAMAGE_MAX = 10;   //攻撃ダメージ
    public GameObject _attackObj;       //攻撃範囲のコライダー
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;

    bool _isAttack = false;

    private void Start()
    {
        _attackObj.SetActive(false);
        _player = transform.parent.gameObject;
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        if (!(SceneManager.GetActiveScene().buildIndex == 1) && !(SceneManager.GetActiveScene().buildIndex == 2))
        {
            _ATTACK_DAMAGE_MAX = PlayerPrefs.GetInt("AttackDamage", _ATTACK_DAMAGE_MAX);
        }
    }

    //敵に当たったらその敵にダメージを与える
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01") || collision.gameObject.CompareTag("MiniBoss") || collision.gameObject.CompareTag("LastBoss") || collision.gameObject.CompareTag("Enemy02"))
        {
            EnemyHPScript _es = collision.GetComponent<EnemyHPScript>();

            _es._damage = _ATTACK_DAMAGE_MAX;
            _isAttack = true;
        }
    }
}
