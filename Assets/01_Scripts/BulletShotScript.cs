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
    private float _speed = 24.0f;
    [SerializeField]
    public int _bulletCount = 5;

    public GameObject _bulletCountUI;
    private Text _bulletCountText;

    [System.NonSerialized]
    public bool _fireSound = false;

    private float _chargeTime = 1;
    private float _chargeTimer;

    public bool _isChargeShotActive;

    private void Start()
    {
        _bulletCountText = _bulletCountUI.GetComponent<Text>();
        _isChargeShotActive = false;
    }

    void Update()
    {
        if ((Input.GetMouseButton(1) || Input.GetKey(KeyCode.K)) && _bulletCount > 0 && !(Input.GetKey(KeyCode.LeftShift)))
        {
            _chargeTimer += Time.deltaTime;
        }
        if (_chargeTimer < _chargeTime && (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.K)))
        {
            _fireSound = true;
            Shot();
            _bulletCount--;
            _chargeTimer = 0;
        }
        else if (_chargeTimer >= _chargeTime && (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.K)) && _isChargeShotActive)
        {
            _fireSound = true;
            ChargeShot();
            _bulletCount = 0;
            _chargeTimer = 0;
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
        GameObject newBall = Instantiate(_bullet, bulletPosition, transform.rotation);
        Vector3 direction = -newBall.transform.forward;
        newBall.GetComponent<Rigidbody>().AddForce(direction * _speed, ForceMode.Impulse);
        newBall.name = _bullet.name;

        Destroy(newBall, 0.8f);
    }
}
