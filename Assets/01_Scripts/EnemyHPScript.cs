using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ほとんど敵のHPの管理をしているだけです
/// 今後インターフェース実装を予定しています
/// </summary>
public class EnemyHPScript : MonoBehaviour
{
    private float _maxHP;
    public Slider _slider;
    public float _currentHP;
    public float _damage;

    private string _enemyType;  //タグによる敵種を取得

    GameObject _player;
    PlayerAttackScript _plAttackScript;

    void Awake()
    {
        _enemyType = gameObject.tag;

        switch (_enemyType)//敵によってHPの設定を変える
        {
            case "Enemy01":
                _maxHP = 100;
                break;
            case "Enemy02":
                _maxHP = 200;
                break;
            case "MiniBoss":
                _maxHP = 500;
                break;
            case "LastBoss":
                _maxHP = 1000;
                break;
            default:
                Debug.LogError("エネミーのHPが設定できませんでした");   //バグ検知用
                break;
        }

        _currentHP = _maxHP;
    }

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
    }

    public void Update()
    {
        //ダメージ計算
        _currentHP -= _damage;
        //UIに値を渡している
        _slider.value = _currentHP / _maxHP;

        if (_currentHP <= 0)
        {
            Destroy(gameObject);
        }
        _damage = 0;

        _slider.transform.rotation = Camera.main.transform.rotation;
    }
}
