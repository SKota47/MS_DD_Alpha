using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMoveScripts : MonoBehaviour
{
    public Rigidbody _rb;
    /* [System.NonSerialized] */
    public float _speed = 20.0f;   //横移動の速度
    public float _maxSpeed = 20.0f;
    private Vector2 _jumpPow = new Vector2(0.0f, 450.0f);   //ジャンプのパワー
    private bool _isJump = false;   //ジャンプしているか

    public int _maxHP = 100;        //最大体力
    public float _currentHP;        //現在の体力
    public static float _publicHP;  //シーン間でHPを共有するためのHPのセーブ的なもの
    private float _damage = 0;      //受けるダメージ
    //以下何からダメージを受けるか
    [System.NonSerialized]
    public int _damageFromReload = 0;   //リロード時に受けるダメージ
    [System.NonSerialized]
    public int _damageByTouch = 0;      //接触によるダメージ
    [System.NonSerialized]
    public int _damageBySystem = 0;     //システム(強化など)によるダメージ

    [System.NonSerialized]
    public int _regainBySystem = 0;     //システム(強化など)による回復

    public Slider _hpBar;            //HPゲージのスライダー
    public GameObject _hpValue;      //UI
    private Text _hpText;            //UI

    public GameObject _attackBox;       //攻撃時の当たり判定Cube
    private Collider _attackCollision;  //当たり判定コライダー(おそらく未使用)
    [System.NonSerialized] public PlayerAttackScript _playerAttackScript;

    public GameObject _chargeAttackBox;       //チャージ攻撃時の当たり判定Cube
    private Collider _chargeAttackCollision;  //当たり判定コライダー(おそらく未使用)
    [System.NonSerialized] public PlayerChargeAttackScript _playerChargeAttackScript;

    public GameObject _bullel;          //弾が射出される場所
    private BulletShotScript _bsShot;   //弾を撃つスクリプト

    public float _attackTime = 0;                   //一回攻撃した後にしばらく攻撃しないためのタイマー
    private const float _ATTACK_TIME_MAX = 0.25f;   //一回攻撃した後にしばらく攻撃しないためのタイマーの最大値
    [System.NonSerialized] public bool _isAttack = false;                 //攻撃しているかどうか
    private const float _ATTACK_DEFUSE_MAX = 2;     //未使用
    private float AttackDefuse = 0;                 //未使用
    [System.NonSerialized] public float _bulletDamage = 5;

    [System.NonSerialized] public bool _playAttackSound = false;
    [System.NonSerialized] public bool _playJumpSound = false;
    [System.NonSerialized] public bool _playRegainSound = false;
    [System.NonSerialized] public bool _playChargeSound = false;//a
    [System.NonSerialized] public bool _playDeadSound = false;//a

    bool _deadSoundPlaymanage = false;

    public GameObject _sealdObj;

    public GameObject _background;

    public int _attackButtonTime;

    private int _attackButtonTimeMax = 60;

    public ParticleSystem _chargeParticlePrefab;
    private ParticleSystem _chargeParticle;

    [System.NonSerialized] public bool _isDead = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //HPがシーン間で共有される仕組み
        //1ステージ目の場合は最大体力だがそれ以外は前のステージのHPをもってくる
        //if内後半は今後消した方がいいかも
        //if (SceneManager.GetActiveScene().buildIndex == 0)
        //{
        //    _currentHP = _maxHP;
        //    _publicHP = _currentHP;
        //}
        //else
        //{
        _maxHP = PlayerPrefs.GetInt("MaxHP", _maxHP);
        _currentHP = PlayerPrefs.GetInt("HP", (int)_maxHP);
        _maxSpeed = PlayerPrefs.GetFloat("Speed", _maxSpeed);
        _bulletDamage = PlayerPrefs.GetFloat("BulletDamage", _bulletDamage);
        //_currentHP = _publicHP;
        // }
        _hpText = _hpValue.GetComponent<Text>();
        _bsShot = _bullel.GetComponent<BulletShotScript>();
        _sealdObj.SetActive(false);
        _playerAttackScript = _attackBox.GetComponent<PlayerAttackScript>();
        _playerChargeAttackScript = _chargeAttackBox.GetComponent<PlayerChargeAttackScript>();
    }

    void Update()
    {
        //_currentHP = _publicHP;
        //移動
        if (!_isDead)
        {
            if (!_background.activeSelf)
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

                    //プレイヤーにダメージ
                    //if (Input.GetKeyDown(KeyCode.P)) _damage = 1;

                    // Debug.Log(_attackButtonTime);

                    //攻撃と攻撃判定オンオフ
                    if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.J)))
                    {
                        _attackButtonTime++;
                    }
                    //チャージ
                    if (_attackButtonTime >= _attackButtonTimeMax)
                    {
                        _speed = 0.0f;
                        _rb.velocity = new Vector3(0, 0, _rb.velocity.z);
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
                    if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.J)) && _attackButtonTime >= _attackButtonTimeMax && !_isAttack)
                    {
                        _chargeParticle.Stop();
                        Destroy(_chargeParticle);
                        _chargeAttackBox.gameObject.SetActive(true);
                        _isAttack = !_isAttack;
                        _playAttackSound = true;
                        _attackButtonTime = 0;
                    }
                    if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.J)) && _attackButtonTime < _attackButtonTimeMax && !_isAttack)
                    {
                        _attackBox.gameObject.SetActive(true);
                        _isAttack = !_isAttack;
                        _playAttackSound = true;
                        _attackButtonTime = 0;
                    }
                    if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.J)))
                    {
                        _attackButtonTime = 0;
                    }
                    //if (Input.GetKeyDown(KeyCode.E) && !_isAttack)
                    //{
                    //    _attackBox.gameObject.SetActive(true);
                    //    _isAttack = !_isAttack;
                    //    _playAttackSound = true;
                    //}
                    else if (_attackTime >= _ATTACK_TIME_MAX)
                    {
                        _attackBox.gameObject.SetActive(false);
                        _isAttack = !_isAttack;
                        _attackTime = 0;
                        _chargeAttackBox.gameObject.SetActive(false);
                    }
                    if (_chargeAttackBox.activeSelf)
                    {
                        _speed = 0.0f;
                        _rb.velocity = new Vector3(0, 0, _rb.velocity.z);
                    }
                    else
                    {
                        _speed = _maxSpeed;
                    }
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
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        _damageFromReload = (5 - _bsShot._bulletCount) * 2;
                        _bsShot._bulletCount = 5;
                    }
                }
                else
                {
                    _rb.velocity = new Vector3(0.0f, _rb.velocity.y, 0.0f);
                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _sealdObj.SetActive(true);
                }
                else
                {
                    _sealdObj.SetActive(false);
                }
            }
        }

        HPCulc();

        //今のHPをstaticのHPへ代入
        _publicHP = _currentHP;
        //Debug.Log(_playerAttackScript._ATTACK_DAMAGE_MAX);
    }

    private void FixedUpdate()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") && _isJump) _isJump = false;  //ジャンプ
    }

    //HPの処理
    private void HPCulc()
    {
        //各種ダメージの計算
        _currentHP -= _damage;
        _currentHP -= _damageFromReload;
        if (_sealdObj.activeSelf) { _damageByTouch /= 2; }
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
}