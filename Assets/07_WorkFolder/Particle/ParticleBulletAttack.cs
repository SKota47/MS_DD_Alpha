using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBulletAttack : MonoBehaviour
{
    public GameObject _bloodParticle;
    public GameObject _bulletAttackParticle;
    GameObject _bloodParticleIns;
    GameObject _bulletAttackParticleIns;

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
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy01") || collision.gameObject.CompareTag("MiniBoss"))
        {
            _bloodParticleIns = Instantiate(_bloodParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            _bulletAttackParticleIns = Instantiate(_bulletAttackParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            Destroy(_bloodParticleIns, 1f);
            Destroy(_bulletAttackParticleIns, 0.5f);
        }
    }
}
