using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//’e©‘Ì‚ÌŠÇ—
public class BulletScript : MonoBehaviour
{
    private float _bulletDamage;
    public GameObject _player;
    private PlayerMoveScripts _playerMoveScripts;
    void Start()
    {
        _playerMoveScripts = _player.GetComponent<PlayerMoveScripts>();
        _bulletDamage = _playerMoveScripts._bulletDamage;
    }

    /// <summary>
    /// G‚ê‚½Û‚É“G‚¾‚Á‚½ê‡“G‚É’e‚Ìƒ_ƒ[ƒW‚ğ”½‰f‚³‚¹‚é
    /// </summary>
    /// <param name="collision">“–‚½‚Á‚½ƒ‚ƒm</param>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01") || collision.gameObject.CompareTag("MiniBoss") || collision.gameObject.CompareTag("LastBoss") || collision.gameObject.CompareTag("Enemy02"))
        {
            EnemyHPScript _es = collision.GetComponent<EnemyHPScript>();
            _es._damage = _bulletDamage;
            Destroy(gameObject);
        }
    }
}
