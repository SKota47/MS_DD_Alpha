using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSpeakerScript : MonoBehaviour
{
    AudioSource _audioSource;   //BGM�\�[�X
    float _loopTime = 15.211f;   //���[�v����n�_

    //�V�[�����܂����ōĐ�����d�g��
    private static bool _isLoad = false;
    private void Awake()
    {
        //�V�������������Ƃ�
        if (_isLoad)    //���̃I�u�W�F�N�g�����݂��Ă�����
        {
            Destroy(gameObject);    //�V����������I�u�W�F�N�g������ 
            return;
        }
        _isLoad = true;
        DontDestroyOnLoad(gameObject);//�V�[���Ԃŏ������Ȃ��w��
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.2f; //���ʒ���
    }

    void Update()
    {
        if (_audioSource.time >= 48.16f) //���y�̍Ō�ɓ��B������_loopTime����Đ�
        {
            _audioSource.time = _loopTime;
        }
    }
}