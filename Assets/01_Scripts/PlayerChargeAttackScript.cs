using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeAttackScript : MonoBehaviour
{
    [System.NonSerialized] public int _CHARGE_ATTACK_DAMAGE_MAX = 20;   //攻撃ダメージ
    public GameObject _attackObj;       //攻撃範囲のコライダー
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;

    bool _isAttack = false;

    private void Start()
    {
        _attackObj.SetActive(false);
        _player = transform.parent.gameObject;
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
    }

    //敵に当たったらその敵にダメージを与える
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01"))
        {
            EnemyHPScript _es = collision.GetComponent<EnemyHPScript>();

            _es._damage = _CHARGE_ATTACK_DAMAGE_MAX;
            _isAttack = true;
        }
    }
}
