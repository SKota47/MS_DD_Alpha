using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �v���C���[�̍U��(�U�����ɏo�铖���蔻��ɃA�^�b�`)
/// </summary>

public class BossAttackScript : MonoBehaviour
{
    [System.NonSerialized] public int _ATTACK_DAMAGE_MAX = 5;   //�U���_���[�W
    //[System.NonSerialized] public int _CHARGE_ATTACK_DAMAGE_MAX = 20;   //�U���_���[�W
    public GameObject _attackObj;       //�U���͈͂̃R���C�_�[
    public GameObject _boss;
    private EnemyBossAI _enemyBossAI;

    bool _isAttack = false;

    private void Start()
    {
        _attackObj.SetActive(false);
        _enemyBossAI = _boss.GetComponent<EnemyBossAI>();
    }

    //�G�ɓ��������炻�̓G�Ƀ_���[�W��^����
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMoveScripts _ps = collision.GetComponent<PlayerMoveScripts>();

            _ps._damageByTouch += _ATTACK_DAMAGE_MAX;
            _isAttack = true;
        }
    }
}
