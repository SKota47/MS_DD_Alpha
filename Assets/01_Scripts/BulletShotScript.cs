using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletShotScript : MonoBehaviour
{
    [SerializeField]
    public GameObject _firingPoint;
    [SerializeField]
    public GameObject _bullet;
    [SerializeField]
    public GameObject _chargeBullet;
    [SerializeField]
    private float _speed = 24.0f;
    [SerializeField]
    public int _bulletCount = 5;

    public GameObject _bulletCountUI;
    private Text _bulletCountText;

    [System.NonSerialized]
    public bool _fireSound = false;

    private float _chargeTime = 1.0f;
    private float _chargeTimer;

    //public bool _isChargeShotActive = true;
    public bool _isChargeShot = false;
    private bool _isShot = false;
    private float _shotIntervalTime = 0.6f;
    private float _shotIntervalTimer;

    public ParticleSystem _chargeParticlePrefab;
    private ParticleSystem _chargeShotParticle;

    private void Start()
    {
        _bulletCountText = _bulletCountUI.GetComponent<Text>();
        //_isChargeShotActive = true;
        _isChargeShot = PlayerPrefsUtil.GetBool("isChargeShot", false);
    }

    void Update()
    {
        if ((Input.GetMouseButton(1) || Input.GetKey(KeyCode.K)) && _bulletCount > 0 && !(Input.GetKey(KeyCode.LeftShift)) && !_isShot)
        {
            _chargeTimer += Time.deltaTime;
        }
        if (_chargeTimer < _chargeTime && (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.K)) && _bulletCount > 0 && !_isShot)
        {
            _fireSound = true;
            Shot();
            _bulletCount--;
            _chargeTimer = 0.0f;
            _isShot = true;
        }
        else if (_chargeTimer >= _chargeTime && (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.K)) && _isChargeShot && _bulletCount >= 5 && !_isShot)
        {
            _fireSound = true;
            ChargeShot();
            _bulletCount = 0;
            _chargeTimer = 0.0f;
            _isShot = true;
        }

        if (_chargeTimer >= _chargeTime && _isChargeShot)
        {
            if (_chargeShotParticle == null)
            {
                _chargeShotParticle = Instantiate(_chargeParticlePrefab);
                _chargeShotParticle.transform.position = transform.position;
                _chargeShotParticle.Play();
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
        }

        if (_shotIntervalTime <= _shotIntervalTimer)
        {
            _isShot = false;
            _chargeTimer = 0.0f;
            _shotIntervalTimer = 0.0f;
        }
        //if ()
        //{

        //}
        _bulletCountText.text = _bulletCount.ToString() + "/5";

        Debug.Log(_chargeTimer);
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
