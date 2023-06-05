using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMoveScripts : MonoBehaviour
{
    Rigidbody _rb;
    private float _speed = 20.0f;   //横移動の速度
    private Vector2 _jumpPow = new Vector2(0.0f, 380.0f);   //ジャンプのパワー
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

    public GameObject _bullel;          //弾が射出される場所
    private BulletShotScript _bsShot;   //弾を撃つスクリプト

    public float _attackTime = 0;                   //一回攻撃した後にしばらく攻撃しないためのタイマー
    private const float _ATTACK_TIME_MAX = 0.25f;   //一回攻撃した後にしばらく攻撃しないためのタイマーの最大値
    private bool _isAttack = false;                 //攻撃しているかどうか
    private const float _ATTACK_DEFUSE_MAX = 2;     //未使用
    private float AttackDefuse = 0;                 //未使用

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //HPがシーン間で共有される仕組み
        //1ステージ目の場合は最大体力だがそれ以外は前のステージのHPをもってくる
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _currentHP = _maxHP;
            _publicHP = _currentHP;
        }
        else
        {
            _currentHP = _publicHP;
        }
        _hpText = _hpValue.GetComponent<Text>();
        _bsShot = _bullel.GetComponent<BulletShotScript>();
    }

    void Update()
    {
        //_currentHP = _publicHP;
        //移動
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            _rb.AddForce(Vector3.up * _jumpPow, ForceMode.Impulse);
            _isJump = true;
        }
        //横移動
        _rb.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y, 0);
        //横移動時の反転
        if (_rb.velocity.x > 0) transform.eulerAngles = new Vector3(0, -90, 0);
        if (_rb.velocity.x < 0) transform.eulerAngles = new Vector3(0, 90, 0);

        //プレイヤーにダメージ
        //if (Input.GetKeyDown(KeyCode.P)) _damage = 1;

        //攻撃と攻撃判定オンオフ
        if (Input.GetKeyDown(KeyCode.E) && !_isAttack)
        {
            _attackBox.gameObject.SetActive(true);
            _isAttack = !_isAttack;
        }
        else if (_attackTime >= _ATTACK_TIME_MAX)
        {
            _attackBox.gameObject.SetActive(false);
            _isAttack = !_isAttack;
            _attackTime = 0;
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

        HPCulc();

        //今のHPをstaticのHPへ代入
        _publicHP = _currentHP;
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
        _currentHP -= _damageByTouch;
        _currentHP -= _damageBySystem;
        //回復の計算
        _currentHP += _regainBySystem;
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