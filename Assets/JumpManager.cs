using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    public GameObject _playerObj;
    private PlayerMoveScripts _playerMoveScript;
    // Start is called before the first frame update
    void Start()
    {
        _playerMoveScript = _playerObj.GetComponent<PlayerMoveScripts>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor") && _playerMoveScript._isJump)
        {
            _playerMoveScript._isJump = false;  //ƒWƒƒƒ“ƒv
        }
    }
}
