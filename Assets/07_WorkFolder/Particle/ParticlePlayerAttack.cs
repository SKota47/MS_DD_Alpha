using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayerAttack : MonoBehaviour
{
    public GameObject _bloodParticle;
    public GameObject _bloodCollisionParticle;
    public GameObject _attackParticle;
    public GameObject _damageParticle;
    GameObject _bloodParticleIns;
    GameObject _bloodCollisionParticleIns;
    GameObject _attackParticleIns;
    GameObject _damageParticleIns;

    PlayerMoveScripts _moveScripts;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_bloodParticleIns != null)
        {
            _bloodParticleIns.transform.position = this.transform.position;
        }
        if (_bloodCollisionParticleIns != null)
        {
            _bloodCollisionParticleIns.transform.position = this.transform.position;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01") || collision.gameObject.CompareTag("MiniBoss"))
        {
            _bloodParticleIns = Instantiate(_bloodParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            _bloodCollisionParticleIns = Instantiate(_bloodCollisionParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            _attackParticleIns = Instantiate(_attackParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            Destroy(_bloodParticleIns, 1f);
            Destroy(_bloodCollisionParticleIns, 1f);
            Destroy(_attackParticleIns, 0.5f);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            _moveScripts = collision.gameObject.GetComponent<PlayerMoveScripts>();
            if (!_moveScripts._isParrySuccessful)
            {
                _bloodParticleIns = Instantiate(_bloodParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
                _bloodCollisionParticleIns = Instantiate(_bloodCollisionParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
                _damageParticleIns = Instantiate(_damageParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
                Destroy(_bloodParticleIns, 1f);
                Destroy(_bloodCollisionParticleIns, 1f);
                Destroy(_damageParticleIns, 0.5f);
            }
        }
    }
}
