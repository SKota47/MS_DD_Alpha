using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveScript : MonoBehaviour
{

    public int _saveHP;
    public float _saveMaxSpeed;
    public int _saveAttackDagame;
    public int _saveChargeAttackDagame;
    public float _saveBulletDamage;

    public GameObject _playerObj;
    public GameObject _attackObj;

    private PlayerMoveScripts _playerMoveScripts;
    private PlayerAttackScript _attackScript;

    void Start()
    {
        _playerMoveScripts = _playerObj.GetComponent<PlayerMoveScripts>();
        _attackScript = _attackObj.GetComponent<PlayerAttackScript>();
    }

    public void DoSave()
    {
    }
}