using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �v���C���[�̍U��(�U�����ɏo�铖���蔻��ɃA�^�b�`)
/// </summary>

public class PlayerAttackScript : MonoBehaviour
{
    [System.NonSerialized] public int _ATTACK_DAMAGE_MAX = 10;   //�U���_���[�W
    public GameObject _attackObj;       //�U���͈͂̃R���C�_�[
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

    //�G�ɓ��������炻�̓G�Ƀ_���[�W��^����
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
