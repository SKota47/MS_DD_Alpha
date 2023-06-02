using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤーの当たり判定(今は敵との接触判定用になってます)
/// </summary>
public class PlayerHitboxScript : MonoBehaviour
{
    public GameObject _playerObj;
    private PlayerMoveScripts _plMove;
    // Start is called before the first frame update
    void Start()
    {
        _plMove = _playerObj.GetComponent<PlayerMoveScripts>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01"))
        {
            _plMove._damageByTouch = 5;
        }
    }
}
