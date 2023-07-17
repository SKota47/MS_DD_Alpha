using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject _gameMnager;
    private CheckEnemyCount _enemyCountS;
    public GameObject _gate;
    private int _nowSceneNum;
    private bool isCheckGoal = false;

    public GameObject _playerObj;
    public GameObject _attackObj;
    public GameObject _chargeAttackObj;

    private PlayerMoveScripts _playerMoveScripts;
    private PlayerAttackScript _attackScript;
    private PlayerChargeAttackScript _chargeAttackScript;

    public GameObject _gameClearObj;

    // Start is called before the first frame update
    void Start()
    {
        //_enemyCountS = _gameMnager.GetComponent<CheckEnemyCount>();
        //_gate.GetComponent<GameObject>().SetActive(false);

        _playerMoveScripts = _playerObj.GetComponent<PlayerMoveScripts>();
        _attackScript = _attackObj.GetComponent<PlayerAttackScript>();
        _chargeAttackScript = _chargeAttackObj.GetComponent<PlayerChargeAttackScript>();
        _nowSceneNum = SceneManager.GetActiveScene().buildIndex;
        _gameClearObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isCheckGoal = false;
        if (Input.GetKeyDown(KeyCode.Return)) isCheckGoal = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (SceneManager.GetActiveScene().buildIndex == 7))
        {
            _gameClearObj.SetActive(true);
        }
        else if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("HP", (int)_playerMoveScripts._currentHP);
            PlayerPrefs.SetFloat("Speed", _playerMoveScripts._maxSpeed);
            PlayerPrefs.SetInt("AttackDamage", _attackScript._ATTACK_DAMAGE_MAX);
            PlayerPrefs.SetFloat("ChargeAttackDamage", _chargeAttackScript._CHARGE_ATTACK_DAMAGE_MAX);
            PlayerPrefs.SetFloat("BulletDamage", _playerMoveScripts._bulletDamage);
            PlayerPrefs.SetInt("MaxHP", _playerMoveScripts._maxHP);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("HP"));
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(2);
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(3);
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(4);
            }
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                SceneManager.LoadScene(5);
            }
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(6);
            }
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                SceneManager.LoadScene(7);
            }
        }
    }
}