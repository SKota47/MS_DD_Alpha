using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeAttackScript : MonoBehaviour
{
    [System.NonSerialized] public int _CHARGE_ATTACK_DAMAGE_MAX = 20;   //�U���_���[�W
    public GameObject _attackObj;       //�U���͈͂̃R���C�_�[
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;

    bool _isAttack = false;

    private void Start()
    {
        _attackObj.SetActive(false);
        _player = transform.parent.gameObject;
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
    }

    //�G�ɓ��������炻�̓G�Ƀ_���[�W��^����
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
