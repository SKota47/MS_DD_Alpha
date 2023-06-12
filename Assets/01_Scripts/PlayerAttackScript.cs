using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// プレイヤーの攻撃(攻撃時に出る当たり判定にアタッチ)
/// </summary>

public class PlayerAttackScript : MonoBehaviour
{
    [System.NonSerialized] public int _ATTACK_DAMAGE_MAX = 10;   //攻撃ダメージ
    public GameObject _attackObj;       //攻撃範囲のコライダー

    bool _isAttack = false;

    private void Start()
    {
        _attackObj.SetActive(false);
    }

    //敵に当たったらその敵にダメージを与える
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01"))
        {
            EnemyHPScript _es = collision.GetComponent<EnemyHPScript>();

            _es._damage = _ATTACK_DAMAGE_MAX;
            _isAttack = true;
        }
    }
}
