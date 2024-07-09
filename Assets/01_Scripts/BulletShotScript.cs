using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�e�̔��ˎ��ɋ쓮���镔��
public class BulletShotScript : MonoBehaviour
{
    public GameObject _firingPoint;     //�ˌ��ʒu
    public GameObject _bullet;          //�e
    public GameObject _chargeBullet;    //�`���[�W�e
    public GameObject _bulletCountUI;   //�c�i����UI

    private float _speed = 24.0f;       //�e��
    public int _bulletCount = 5;        //�e�̐�
    private const float _CHARGE_TIME = 3.0f;   //�`���[�W���鎞��
    private float _chargeTimer;         //�`���[�W���Ă��鎞��

    private Text _bulletCountText;      //UI�ɃA�^�b�`����e�L�X�g

    public bool _isChargeShot = false;  //�`���[�W�V���b�g���ǂ���
    private bool _isShot = false;
    private float _shotIntervalTime = 0.6f;
    private float _shotIntervalTimer;

    public bool _fireSound = false;

    //�`���[�W�������ɔ�������G�t�F�N�g
    public ParticleSystem _chargeParticlePrefab;
    private ParticleSystem _chargeShotParticle;

    public ParticleSystem _chargedParticlePrefab;
    private ParticleSystem _chargedShotParticle;

    private void Start()
    {
        _bulletCountText = _bulletCountUI.GetComponent<Text>();
        _isChargeShot = PlayerPrefsUtil.GetBool("isChargeShot", false);
    }

    void Update()
    {
        if ((Input.GetMouseButton(1) || Input.GetKey(KeyCode.K)) && _bulletCount > 0 && !(Input.GetKey(KeyCode.LeftShift)) && !_isShot)
        {
            _chargeTimer += Time.deltaTime;
        }
        if (_chargeTimer < _CHARGE_TIME && (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.K)) && _bulletCount > 0 && !_isShot)
        {
            _fireSound = true;
            Shot();
            _bulletCount--;
            _chargeTimer = 0.0f;
            _isShot = true;
        }
        else if (_chargeTimer >= _CHARGE_TIME && (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.K)) && _isChargeShot && _bulletCount >= 5 && !_isShot)
        {
            _fireSound = true;
            ChargeShot();
            _bulletCount = 0;
            _chargeTimer = 0.0f;
            _isShot = true;
        }

        if (_chargeTimer >= 1 && _isChargeShot && _chargeTimer < _CHARGE_TIME && _bulletCount >= 5)
        {
            if (_chargedShotParticle == null)
            {
                _chargedShotParticle = Instantiate(_chargedParticlePrefab);
                _chargedShotParticle.transform.position = transform.position;
                _chargedShotParticle.Play();
            }
            if (_chargedShotParticle != null)
            {
                _chargedShotParticle.transform.position = transform.position;
            }
        }

        if (_chargeTimer >= _CHARGE_TIME && _isChargeShot && _bulletCount >= 5)
        {
            if (_chargeShotParticle == null)
            {
                _chargeShotParticle = Instantiate(_chargeParticlePrefab);
                _chargeShotParticle.transform.position = transform.position;
                _chargeShotParticle.Play();
                _chargedShotParticle.time = _chargedShotParticle.time;
                Destroy(_chargedShotParticle);
            }
            if (_chargeShotParticle != null)
            {
                _chargeShotParticle.transform.position = transform.position;
            }
        }

        if (_isShot)
        {
            _shotIntervalTimer += Time.deltaTime;
        }
        if (!Input.GetMouseButton(1) && !Input.GetKey(KeyCode.K))
        {
            _chargeTimer = 0.0f;
            _isShot = false;
            if (_chargeShotParticle)
            {
                _chargeShotParticle.Stop();
                Destroy(_chargeShotParticle);
            }
            if (_chargedShotParticle)
            {
                _chargedShotParticle.Stop();
                Destroy(_chargedShotParticle);
            }
        }

        if (_shotIntervalTime <= _shotIntervalTimer)
        {
            _isShot = false;
            _chargeTimer = 0.0f;
            _shotIntervalTimer = 0.0f;
        }
        _bulletCountText.text = _bulletCount.ToString() + "/5";

    }

    private void Shot()
    {
        Vector3 bulletPosition = _firingPoint.transform.position;
        GameObject newBall = Instantiate(_bullet, bulletPosition, transform.rotation);
        Vector3 direction = -newBall.transform.forward;
        newBall.GetComponent<Rigidbody>().AddForce(direction * _speed, ForceMode.Impulse);
        newBall.name = _bullet.name;

        Destroy(newBall, 0.8f);
    }

    private void ChargeShot()
    {
        Vector3 bulletPosition = _firingPoint.transform.position;
        GameObject newBall = Instantiate(_chargeBullet, bulletPosition, transform.rotation);
        Vector3 direction = -newBall.transform.forward;
        newBall.GetComponent<Rigidbody>().AddForce(direction * _speed, ForceMode.Impulse);
        newBall.name = _chargeBullet.name;

        Destroy(newBall, 1.0f);
    }
}
