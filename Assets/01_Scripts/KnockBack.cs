using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockBackPower = 1;   // ノックバックさせる力

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy01"))
        {
            Rigidbody _rbOther = other.GetComponent<Rigidbody>();
            EnemyBossAI _otherAi = other.GetComponent<EnemyBossAI>();

            if (!_otherAi._isKnockback)
            {
                _otherAi._isKnockback = true;
                _otherAi.agent.enabled = false;
            }
        }

    }
}