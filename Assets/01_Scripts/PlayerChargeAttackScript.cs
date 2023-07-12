using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChargeAttackScript : MonoBehaviour
{
    [System.NonSerialized] public int _CHARGE_ATTACK_DAMAGE_MAX = 20;   //�U���_���[�W
    public GameObject _chargeAttackBox;       //�U���͈͂̃R���C�_�[
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;

    bool _isAttack = false;

    private void Start()
    {
        _chargeAttackBox.SetActive(false);
        _player = transform.parent.gameObject;
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        if (!(SceneManager.GetActiveScene().buildIndex == 0) && !(SceneManager.GetActiveScene().buildIndex == 1))
        {
            _CHARGE_ATTACK_DAMAGE_MAX = PlayerPrefs.GetInt("ChargeAttackDamage", _CHARGE_ATTACK_DAMAGE_MAX);
        }
    }

    //�G�ɓ��������炻�̓G�Ƀ_���[�W��^����
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
