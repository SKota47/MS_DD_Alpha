using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    // Start���\�b�h�Ȃǂŕϐ��ɂ͒l�����ςƂ���
    private int _isKinematicOffFrame = 1;
    public float knockBackPower = 1;   // �m�b�N�o�b�N�������
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy01"))
        {
            Rigidbody _rbOther = other.GetComponent<Rigidbody>();
            EnemyBossAI _otherAi = other.GetComponent<EnemyBossAI>();

            //if (_otherAi._isKinematicOnFrame == _isKinematicOffFrame) { return; }
            if (!_otherAi._isKnockback)
            {
                _isKinematicOffFrame = Time.frameCount;
                _otherAi._isKnockback = true;
                _otherAi.agent.enabled = false;
                //_rbOther.isKinematic = false;

                //_rbOther.velocity = Vector3.zero;

                // �����̈ʒu�ƐڐG���Ă����I�u�W�F�N�g�̈ʒu�Ƃ��v�Z���āA�����ƕ������o���Đ��K��(���x�x�N�g�����Z�o)
               // Vector3 distination = (transform.position - other.transform.position).normalized;

                //_rbOther.AddForce(new Vector3(distination.x * knockBackPower, 0, 0), ForceMode.Impulse);
            }
        }

    }
}