using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//enum PlayerAnimatorState
//{
//    isRun, isJump, isClawAttack
//}

public class PlayerMoveScripts : MonoBehaviour
{
    public Rigidbody _rb;
    /* [System.NonSerialized] */
    public float _speed = 10.0f;   //横移動の速度
    public float _maxSpeed = 10.0f;
    private Vector2 _jumpPow = new Vector2(0.0f, 450.0f);   //ジャンプのパワー
    public bool _isJump = false;   //ジャンプしているか

    public int _maxHP = 100;        //最大体力
    public float _currentHP;        //現在の体力
    public static float _publicHP;  //シーン間でHPを共有するためのHPのセーブ的なもの
    private float _damage = 0;      //受けるダメージ

    //以下何からダメージを受けるか(回復するか)
    [System.NonSerialized]
    public int _damageFromReload = 0;   //リロード時に受けるダメージ
    [System.NonSerialized]
    public int _damageByTouch = 0;      //接触によるダメージ
    [System.NonSerialized]
    public int _damageBySystem = 0;     //システム(強化など)によるダメージ

    [System.NonSerialized]
    public int _regainBySystem = 0;     //システム(強化など)による回復
    //


    public Slider _hpBar;            //HPゲージのスライダー
    public GameObject _hpValue;      //UI
    private Text _hpText;            //UI

    public GameObject _attackBox;       //攻撃時の当たり判定Cube
    [System.NonSerialized] public PlayerAttackScript _playerAttackScript;

    public GameObject _chargeAttackBox;       //チャージ攻撃時の当たり判定Cube
    [System.NonSerialized] public PlayerChargeAttackScript _playerChargeAttackScript;

    public GameObject _bullel;          //弾が射出される場所
    private BulletShotScript _bsShot;   //弾を撃つスクリプト

    public float _attackTime = 0;                   //一回攻撃した後にしばらく攻撃しないためのタイマー
    private const float _ATTACK_TIME_MAX = 0.25f;   //一回攻撃した後にしばらく攻撃しないためのタイマーの最大値
    [System.NonSerialized] public bool _isAttack = false;                 //攻撃しているかどうか
    [System.NonSerialized] public float _bulletDamage = 5;                //弾の攻撃力
    [System.NonSerialized] public float _chargeBulletDamage = 100;        //チャージした弾の攻撃力

    //サウンド-----------------------------------------------------------------
    //サウンドのオンオフ
    [System.NonSerialized] public bool _playAttackSound = false;
    [System.NonSerialized] public bool _playJumpSound = false;
    [System.NonSerialized] public bool _playRegainSound = false;
    [System.NonSerialized] public bool _playChargeSound = false;//a
    [System.NonSerialized] public bool _playDeadSound = false;//a
    [System.NonSerialized] public bool _playParrySound = false;

    bool _deadSoundPlaymanage = false;
    public GameObject _sealdObj;

    public GameObject _background;

    public float _attackButtonTime;
    private float _attackButtonTimeMax = 2.5f;

    public ParticleSystem _chargeParticlePrefab;
    private ParticleSystem _chargeParticle;

    [System.NonSerialized] public bool _isDead = false;

    //public SphereCollider _footCollider;

    public bool _isParrySuccessful = false;
    [System.NonSerialized] public float _chanceTimer = 0;

    public GameObject _parryEffect;
    private GameObject _parryEffectIns;

    public GameObject _nailTrailObj;
    public GameObject _chargeNailTrailObj;

    public Animator _playerAnimator;

    private const float _attackIntervalTIme = 1;
    private float _attackIntervalTImer;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _maxSpeed = 10.0f;
        _maxHP = PlayerPrefs.GetInt("MaxHP", _maxHP);
        _currentHP = PlayerPrefs.GetInt("HP", (int)_maxHP);
        _maxSpeed = PlayerPrefs.GetFloat("Speed", _maxSpeed);
        _bulletDamage = PlayerPrefs.GetFloat("BulletDamage", _bulletDamage);

        _hpText = _hpValue.GetComponent<Text>();
        _bsShot = _bullel.GetComponent<BulletShotScript>();
        _sealdObj.SetActive(false);
        _playerAttackScript = _attackBox.GetComponent<PlayerAttackScript>();
        _playerChargeAttackScript = _chargeAttackBox.GetComponent<PlayerChargeAttackScript>();

        _playerAnimator = GetComponentInChildren<Animator>();

        _nailTrailObj.SetActive(false);
        _chargeNailTrailObj.SetActive(false);
    }

    void Update()
    {
        //移動
        if (!_background.activeSelf && !_isDead)
        {
            if (!_sealdObj.activeSelf)
            {

                //ジャンプ
                if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
                {
                    _rb.AddForce(Vector3.up * _jumpPow, ForceMode.Impulse);
                    _isJump = true;
                    _playJumpSound = true;
                }

                //横移動
                _rb.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y, 0);
                //横移動時の反転
                if (_rb.velocity.x > 0) transform.eulerAngles = new Vector3(0, -90, 0);
                if (_rb.velocity.x < 0) transform.eulerAngles = new Vector3(0, 90, 0);

                UnityEngine.Debug.Log(_attackButtonTime);

                //攻撃処理-----------------------------------------------------------------------
                //攻撃と攻撃判定オンオフ
                if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.J)))
                {
                    _attackButtonTime += Time.deltaTime;
                }
                //チャージした時のエフェクトやサウンドの処理
                if (_attackButtonTime >= _attackButtonTimeMax)
                {
                    //パーティクル処理
                    if (_chargeParticle == null)
                    {
                        _chargeParticle = Instantiate(_chargeParticlePrefab);
                        _chargeParticle.transform.position = transform.position;
                        _chargeParticle.Play();
                        _playChargeSound = true;//a
                    }
                    if (_chargeParticle != null)
                    {
                        _chargeParticle.transform.position = transform.position;
                    }
                }
                //攻撃ボタンの押下時間による攻撃方法の推移
                //一定時間以上押下...チャージ攻撃
                if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.J)) && _attackButtonTime >= _attackButtonTimeMax && !_isAttack)
                {
                    _chargeParticle.Stop();
                    Destroy(_chargeParticle);
                    _chargeNailTrailObj.SetActive(true);
                    _chargeAttackBox.gameObject.SetActive(true);
                    _isAttack = !_isAttack;
                    _playAttackSound = true;
                    _attackButtonTime = 0;
                }
                //一定時間に満たない...通常攻撃
                if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.J)) && _attackButtonTime < _attackButtonTimeMax && !_isAttack)
                {
                    _attackBox.gameObject.SetActive(true);
                    _nailTrailObj.SetActive(true);
                    _isAttack = !_isAttack;
                    _playAttackSound = true;
                    _attackButtonTime = 0;
                    _playerAnimator.SetBool("isAttack2", true);
                }
                //押下時間をリセット
                if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.J)))
                {
                    _attackButtonTime = 0;
                }
                //攻撃間隔の調整(連撃出来ないように)
                else if (_attackTime >= _ATTACK_TIME_MAX)
                {
                    _attackBox.gameObject.SetActive(false);
                    _isAttack = !_isAttack;
                    _attackTime = 0;

                    _chargeAttackBox.gameObject.SetActive(false);
                    _nailTrailObj.SetActive(false);
                    _chargeNailTrailObj.SetActive(false);
                    _playerAnimator.SetBool("isAttack2", false);
                }
                //チャージ攻撃中のプレイヤー座標移動を停止
                if (_chargeAttackBox.activeSelf)
                {
                    _speed = 0.0f;
                    _rb.velocity = new Vector3(0, 0, _rb.velocity.z);
                }
                else
                {
                    _speed = _maxSpeed;
                }
                //通常攻撃中のプレイヤー座標移動を停止
                if (_attackBox.activeSelf)
                {
                    _speed = 0.0f;
                    _rb.velocity = new Vector3(0, 0, _rb.velocity.z);
                }
                else
                {
                    _speed = _maxSpeed;
                }
                if (_isAttack)
                {
                    _attackTime += Time.deltaTime;
                }
                //リロード時にダメージ
                if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().buildIndex != 1)
                {
                    _damageFromReload = (5 - _bsShot._bulletCount) * 2;
                    _bsShot._bulletCount = 5;
                }
            }

            //シールド-------------------------------------------------------
            //シールドを張っている場合は移動不可
            else
            {
                _rb.velocity = new Vector3(0.0f, _rb.velocity.y, 0.0f);
            }
            //シールド展開
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _sealdObj.SetActive(true);
            }
            else
            {
                _sealdObj.SetActive(false);
            }
        }
        //パリィの時間、判定のリセット
        if (!_sealdObj.activeSelf)
        {
            _chanceTimer = 0;
            _isParrySuccessful = false;
        }

        //最終HP調整
        HPCulc();

        //今のHPをstaticのHPへ代入(引継ぎ)
        _publicHP = _currentHP;
    }

    //HPの処理
    private void HPCulc()
    {
        //計算順
        //自傷、ダメージ計算-->シールドもしくは-->回復計算
        //各種ダメージの計算
        _currentHP -= _damage;
        _currentHP -= _damageFromReload;
        if (_sealdObj.activeSelf)
        {
            _damageByTouch /= 2;
        }
        if (_isParrySuccessful)
        {
            _damageByTouch = 0;
        }
        _currentHP -= _damageByTouch;
        _currentHP -= _damageBySystem;
        //回復の計算
        if (_currentHP < _maxHP)
        {
            _currentHP += _regainBySystem;
            if (_regainBySystem != 0) _playRegainSound = true;
        }

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            _isDead = true;
            if (!_deadSoundPlaymanage)
            {
                _playDeadSound = true;
                _deadSoundPlaymanage = true;
            }
        }

        if (_currentHP >= _maxHP) _currentHP = _maxHP;
        //UIへHPの転送
        _hpBar.value = _currentHP / _maxHP;
        _hpText.text = _currentHP.ToString();

        //計算後ダメージを初期化
        _damage = 0;
        _damageFromReload = 0;
        _damageByTouch = 0;
        _damageBySystem = 0;
        _regainBySystem = 0;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("AttackBoxTag"))
        {
            if (_isParrySuccessful)
            {
                _playParrySound = true;
                GameObject _enemyObj = collision.gameObject.transform.parent.gameObject;
                EnemyHPScript _enemyHpScript = _enemyObj.GetComponent<EnemyHPScript>();
                BossAttackScript _enemyAttackScript = collision.gameObject.GetComponent<BossAttackScript>();
                _damageByTouch = 0;
                _enemyHpScript._damage = _enemyAttackScript._ATTACK_DAMAGE_MAX;
                //_isParrySuccessful = false;
                _parryEffectIns = Instantiate(_parryEffect, transform.position, Quaternion.identity);
                Destroy(_parryEffectIns, 1f);
            }
        }
    }

}