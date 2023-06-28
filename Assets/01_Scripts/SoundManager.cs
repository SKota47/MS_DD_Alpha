using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip _meleeAtackSound;
    public AudioClip _strengthenSound;
    public AudioClip _bulletFireSound;
    public AudioClip _regainSound;
    public AudioClip _jumpSound;
    public AudioClip _damageSound;
    public AudioClip _chargeSound;
    public AudioClip _deadSound;
    public AudioClip _cancelSound;
    public AudioClip _decisionSound;

    AudioSource _audioSource;
    public GameObject _audioSourceobj;
    private AudioSource _BGMSource;

    bool _isAttackSoundPlay;

    public GameObject _playerObj;
    private PlayerMoveScripts _playerScript;
    private BulletShotScript _bulletShotScript;
    public GameObject _Menu;
    private MenuScript _menuScript;
    public GameObject _backGroundCanvas;

    bool _backgroundcheck = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerScript = _playerObj.GetComponent<PlayerMoveScripts>();
        _bulletShotScript = _playerObj.GetComponent<BulletShotScript>();
        _menuScript = _Menu.GetComponent<MenuScript>();
        //_audioSourceobj = GameObject.FindGameObjectWithTag("BGM");
        _BGMSource = _audioSourceobj.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_playerScript._playAttackSound)
        {
            _audioSource.volume = 1.0f;
            _audioSource.PlayOneShot(_meleeAtackSound);
            _playerScript._playAttackSound = false;
        }

        if (_bulletShotScript._fireSound)
        {
            _audioSource.volume = 1.0f;
            _audioSource.PlayOneShot(_bulletFireSound);
            _bulletShotScript._fireSound = false;
        }

        if (_playerScript._playJumpSound)
        {
            _audioSource.volume = 0.5f;
            _audioSource.PlayOneShot(_jumpSound);
            _playerScript._playJumpSound = false;
        }

        if (_playerScript._playRegainSound)
        {
            _audioSource.volume = 1.0f;
            _audioSource.PlayOneShot(_regainSound);
            _playerScript._playRegainSound = false;
        }

        if (_playerScript._playChargeSound)
        {
            _audioSource.volume = 1.0f;
            _audioSource.PlayOneShot(_chargeSound);
            _playerScript._playChargeSound = false;
        }

        if (_menuScript._desiSound)
        {
            _audioSource.volume = 1.0f;
            _audioSource.PlayOneShot(_decisionSound);
            _menuScript._desiSound = false;
        }
        if (_menuScript._canselSound)
        {
            _audioSource.volume = 1.0f;
            _audioSource.PlayOneShot(_cancelSound);
            _menuScript._canselSound = false;
        }
        //if (_playerScript._playDeadSound)
        //{
        //    _BGMSource.Pause();
        //    _audioSource.volume = 0.3f;
        //    _audioSource.PlayOneShot(_deadSound);
        //    _playerScript._playDeadSound = false;
        //}
        if (!_backGroundCanvas.activeSelf && !_backgroundcheck)
        {
            _audioSource.volume = 1.0f;
            _audioSource.PlayOneShot(_strengthenSound);
            _backgroundcheck = true;
        }
    }
}