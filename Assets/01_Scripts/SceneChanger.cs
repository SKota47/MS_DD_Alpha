using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ステージ間の遷移
/// </summary>
public class SceneChanger : MonoBehaviour
{
    public GameObject _gameMnager;
    public GameObject _gate;

    public GameObject _playerObj;
    public GameObject _attackObj;
    public GameObject _chargeAttackObj;

    private PlayerMoveScripts _playerMoveScripts;
    private PlayerAttackScript _attackScript;
    private PlayerChargeAttackScript _chargeAttackScript;
    private BulletShotScript _bulletShotScript;

    public GameObject _gameClearObj;

    // Start is called before the first frame update
    void Start()
    {
        _playerMoveScripts = _playerObj.GetComponent<PlayerMoveScripts>();
        _attackScript = _attackObj.GetComponent<PlayerAttackScript>();
        _chargeAttackScript = _chargeAttackObj.GetComponent<PlayerChargeAttackScript>();
        _bulletShotScript = _playerObj.GetComponent<BulletShotScript>();

        _gameClearObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (SceneManager.GetActiveScene().buildIndex == 8))
        {
            _gameClearObj.SetActive(true);
        }
        else if (other.tag == "Player")
        {
            //各保存内容をPlayerPrefsに保存
            PlayerPrefs.SetInt("HP", (int)_playerMoveScripts._currentHP);
            PlayerPrefs.SetFloat("Speed", _playerMoveScripts._maxSpeed);
            PlayerPrefs.SetInt("AttackDamage", _attackScript._ATTACK_DAMAGE_MAX);
            PlayerPrefs.SetFloat("ChargeAttackDamage", _chargeAttackScript._CHARGE_ATTACK_DAMAGE_MAX);
            PlayerPrefs.SetFloat("BulletDamage", _playerMoveScripts._bulletDamage);
            PlayerPrefs.SetFloat("ChargeBulletDamage", _playerMoveScripts._chargeBulletDamage);
            PlayerPrefs.SetInt("MaxHP", _playerMoveScripts._maxHP);
            PlayerPrefsUtil.SetBool("isChargeShot", _bulletShotScript._isChargeShot);
            PlayerPrefs.Save();
            //遷移
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}