using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �قƂ�ǓG��HP�̊Ǘ������Ă��邾���ł�
/// ����C���^�[�t�F�[�X������\�肵�Ă��܂�
/// </summary>
public class EnemyHPScript : MonoBehaviour
{
    private float _maxHP;
    public Slider _slider;
    public float _currentHP;
    public float _damage;

    private string _enemyType;  //�^�O�ɂ��G����擾

    GameObject _player;
    PlayerAttackScript _plAttackScript;

    void Awake()
    {
        _enemyType = gameObject.tag;

        switch (_enemyType)//�G�ɂ����HP�̐ݒ��ς���
        {
            case "Enemy01":
                _maxHP = 50;
                break;
            case "Enemy02":
                _maxHP = 20;
                break;
            case "MiniBoss":
                _maxHP = 150;
                break;
            default:
                Debug.LogError("�G�l�~�[��HP���ݒ�ł��܂���ł���");   //�o�O���m�p
                break;
        }

        _currentHP = _maxHP;
    }

    private void Start()
    {
        //_player = GameObject.Find("AttackBox");
        //_plAttackScript = _player.GetComponent<PlayerAttackScript>();
        _slider = GetComponentInChildren<Slider>();
    }

    public void Update()
    {
        //�_���[�W�v�Z
        _currentHP -= _damage;
        //UI�ɒl��n���Ă���
        _slider.value = _currentHP / _maxHP;

        if (_currentHP <= 0)
        {
            Destroy(gameObject);
        }
        _damage = 0;

        _slider.transform.rotation = Camera.main.transform.rotation;
    }
}
