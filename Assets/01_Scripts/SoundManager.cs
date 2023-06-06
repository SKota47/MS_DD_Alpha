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
    AudioSource _audioSource;

    bool _isAttackSoundPlay;

    public GameObject _playerObj;
    private PlayerMoveScripts _playerScript;
    private BulletShotScript _bulletShotScript;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerScript = _playerObj.GetComponent<PlayerMoveScripts>();
        _bulletShotScript = _playerObj.GetComponent<BulletShotScript>();
    }

    void Update()
    {
        if (_playerScript._playAttackSound)
        {
            _audioSource.PlayOneShot(_meleeAtackSound);
            _playerScript._playAttackSound = false;
        }

        if (_bulletShotScript._fireSound)
        {
            _audioSource.PlayOneShot(_bulletFireSound);
            _bulletShotScript._fireSound = false;
        }

        if (_playerScript._playJumpSound)
        {
            _audioSource.PlayOneShot(_jumpSound);
            _playerScript._playJumpSound = false;
        }

        if (_playerScript._playRegainSound)
        {
            _audioSource.PlayOneShot(_regainSound);
            _playerScript._playRegainSound = false;
        }
    }
}
