using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// プレイヤーの攻撃(攻撃時に出る当たり判定にアタッチ)
/// </summary>

public class BossAttackScript : MonoBehaviour
{
    [System.NonSerialized] public int _ATTACK_DAMAGE_MAX = 5;   //攻撃ダメージ
    //[System.NonSerialized] public int _CHARGE_ATTACK_DAMAGE_MAX = 20;   //攻撃ダメージ
    public GameObject _attackObj;       //攻撃範囲のコライダー
    public GameObject _boss;
    private EnemyBossAI _enemyBossAI;

    bool _isAttack = false;

    public int _enemyData;

    private void Start()
    {
        _attackObj.SetActive(false);
        _enemyBossAI = _boss.GetComponent<EnemyBossAI>();
        _enemyData = transform.parent.GetInstanceID();
    }

    //敵に当たったらその敵にダメージを与える
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMoveScripts _ps = collision.GetComponent<PlayerMoveScripts>();
            if (_ps._isParrySuccessful)
            {
                _ps._damageByTouch = 0;
            }
            else
            { _ps._damageByTouch += _ATTACK_DAMAGE_MAX; }
            _isAttack = true;
        }
    }
}
