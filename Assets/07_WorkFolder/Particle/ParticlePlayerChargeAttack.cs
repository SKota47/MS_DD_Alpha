using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayerChargeAttack : MonoBehaviour
{
    public GameObject _bloodParticle;
    public GameObject _chargeAttackParticle;
    GameObject _bloodParticleIns;
    GameObject _bloodParticleIns2;
    GameObject _chargeAttackParticleIns;

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
            _bloodParticleIns2 = Instantiate(_bloodParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            _chargeAttackParticleIns = Instantiate(_chargeAttackParticle, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            Destroy(_bloodParticleIns, 1f);
            Destroy(_bloodParticleIns2, 1f);
            Destroy(_chargeAttackParticleIns, 0.5f);
        }
    }
}
