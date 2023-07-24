using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharaData : MonoBehaviour
{
    public TextMeshProUGUI atk;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI rangeAtk;

    public GameObject _player;
    public GameObject _attackBox;
    private float _bulletDamage;
    private float _ATTACK_DAMAGE_MAX;
    private PlayerMoveScripts playerMoveScripts;
    private PlayerAttackScript playerAttackScript;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _bulletDamage = playerMoveScripts._bulletDamage;
        playerAttackScript = _attackBox.GetComponent<PlayerAttackScript>();
        _ATTACK_DAMAGE_MAX = playerAttackScript._ATTACK_DAMAGE_MAX;
        UpdateUI1();
        UpdateUI2();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void UpdateUI1()
    {
        if (playerMoveScripts != null)
        {
            //atk.text = "ATK:" + playerAttackScript._ATTACK_DAMAGE_MAX;
            speed.text = "ë¨ìx:" + playerMoveScripts._maxSpeed;
            rangeAtk.text = "âìãóó£çUåÇóÕ:" + playerMoveScripts._bulletDamage;
        }
    }
    void UpdateUI2()
    {
        if (playerAttackScript != null)
        {
            atk.text = "ãﬂê⁄çUåÇóÕ:" + playerAttackScript._ATTACK_DAMAGE_MAX;
        }
    }
}
