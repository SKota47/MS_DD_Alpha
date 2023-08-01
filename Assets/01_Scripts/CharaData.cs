using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharaData : MonoBehaviour
{
    public TextMeshProUGUI _atkText;
    public TextMeshProUGUI _rangeAtkText;
    public TextMeshProUGUI _speedText;

    private GameObject _playerObj;
    private GameObject _attackBoxObj;

    private PlayerMoveScripts _playerMoveScript;
    private PlayerAttackScript _playerAttackScript;

    // Start is called before the first frame update
    void Start()
    {
        _playerObj = GameObject.Find("Player");
        _playerMoveScript = _playerObj.GetComponent<PlayerMoveScripts>();
        _playerAttackScript = _playerObj.transform.Find("AttackBox").GetComponent<PlayerAttackScript>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI1();
    }
    void UpdateUI1()
    {
        _atkText.text = _playerAttackScript._ATTACK_DAMAGE_MAX.ToString();
        _speedText.text = _playerMoveScript._maxSpeed.ToString();
        _rangeAtkText.text = _playerMoveScript._bulletDamage.ToString();
    }
    void UpdateUI2()
    {
    }
}