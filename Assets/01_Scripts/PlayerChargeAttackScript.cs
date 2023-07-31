using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChargeAttackScript : MonoBehaviour
{
    [System.NonSerialized] public float _CHARGE_ATTACK_DAMAGE_MAX = 10;   //攻撃ダメージ
    public GameObject _chargeAttackBox;       //攻撃範囲のコライダー
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;
    public GameObject _attackBox;
    private PlayerAttackScript _playerAttackScript;

    bool _isAttack = false;

    private void Start()
    {
        _chargeAttackBox.SetActive(false);
        _player = transform.parent.gameObject;
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _playerAttackScript = _attackBox.GetComponent<PlayerAttackScript>();
        if (!(SceneManager.GetActiveScene().buildIndex == 1) /*&& !(SceneManager.GetActiveScene().buildIndex == 1)*/)
        {
            _CHARGE_ATTACK_DAMAGE_MAX = PlayerPrefs.GetFloat("AttackDamage", _playerAttackScript._ATTACK_DAMAGE_MAX) * 2;
        }
    }

    //敵に当たったらその敵にダメージを与える
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01") || collision.gameObject.CompareTag("Enemy02") || collision.gameObject.CompareTag("MiniBoss") || collision.gameObject.CompareTag("LastBoss"))
        {
            EnemyHPScript _es = collision.GetComponent<EnemyHPScript>();

            _es._damage = _CHARGE_ATTACK_DAMAGE_MAX;
            _isAttack = true;
        }
    }
}
