using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryScript : MonoBehaviour
{
    public GameObject _player;
    public GameObject _attackObj;
    private GameObject _shieldObj;
    private PlayerMoveScripts _moveScript;
    private PlayerAttackScript _attackScript;

    public Material _shieldMaterial;
    public Material _parryShieldMaterial;

    private float _chanceTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        _moveScript = _player.GetComponent<PlayerMoveScripts>();
        _attackScript = _attackObj.GetComponent<PlayerAttackScript>();
        gameObject.GetComponent<Renderer>().material = _shieldMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            _moveScript._chanceTimer += Time.deltaTime;
            if (_moveScript._chanceTimer <= _chanceTime)
            {
                _moveScript._isParrySuccessful = true;
            }
            else
            {
                _moveScript._isParrySuccessful = false;
            }
        }
        else
        {
            _moveScript._isParrySuccessful = false;
            _moveScript._chanceTimer = 0;
        }

        //if (_moveScript._isParrySuccessful)
        //{
        //    gameObject.GetComponent<Renderer>().material = _parryShieldMaterial;
        //}
        //else
        //{
        //    gameObject.GetComponent<Renderer>().material = _shieldMaterial;
        //}
    }
}