using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �v���C���[�̍U��(�U�����ɏo�铖���蔻��ɃA�^�b�`)
/// </summary>

public class PlayerAttackScript : MonoBehaviour
{
    [System.NonSerialized] public int _ATTACK_DAMAGE_MAX = 10;   //�U���_���[�W
    public GameObject _attackObj;       //�U���͈͂̃R���C�_�[

    bool _isAttack = false;

    private void Start()
    {
        _attackObj.SetActive(false);
    }

    //�G�ɓ��������炻�̓G�Ƀ_���[�W��^����
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
