using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMSpeakerScript : MonoBehaviour
{
    AudioSource _audioSource;   //BGM�\�[�X
    public AudioClip _BGM_Field;
    public AudioClip _BGM_MiniBoss;
    public int _miniBossStageSceneNum = 3;
    public int _bossStageSceneNum = 7;

    private bool _isMiniBossStage = false;

    float _fieldBGMLoopTime = 15.211f;   //���[�v����n�_
    float _miniBossBGMLoopTime = 12.857f;   //���[�v����n�_

    private float _fieldBGMLength;
    private float _miniBossBGMLength;

    private bool _throughOnece = false;

    //�V�[�����܂����ōĐ�����d�g��
    private static bool _isLoad = false;

    private Scene _saveScene;
    private Scene _currentScene;

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
        _audioSource.clip = _BGM_Field;
        _fieldBGMLength = _BGM_Field.length;
        _miniBossBGMLength = _BGM_MiniBoss.length;
    }

    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (_audioSource.time >= 48.16f && !_isMiniBossStage) //���y�̍Ō�ɓ��B������_fieldBGMLoopTime����Đ�
        {
            _audioSource.time = _fieldBGMLoopTime;
        }
        if (_audioSource.time >= _miniBossBGMLength - 0.1 && _isMiniBossStage)
        {
            _audioSource.time = _miniBossBGMLoopTime;
        }
    }

    void ChangeBGMByStage()
    {
        //if (SceneManager.GetActiveScene().buildIndex != _miniBossStageSceneNum || SceneManager.GetActiveScene().buildIndex != _bossStageSceneNum)
        //{
        //    _isMiniBossStage = false;
        //    _throughOnece = false;
        //}
        //else if (SceneManager.GetActiveScene().buildIndex == _miniBossStageSceneNum || SceneManager.GetActiveScene().buildIndex == _bossStageSceneNum)
        //{
        //    _isMiniBossStage = true;
        //}

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 4:
                _isMiniBossStage = true;
                break;
            case 8:
                _isMiniBossStage = true;
                break;
            default:
                _isMiniBossStage = false;
                _throughOnece = false;
                break;
        }



        if (_isMiniBossStage && !_throughOnece && _audioSource.clip != _BGM_MiniBoss)
        {
            _audioSource.Stop();
            _audioSource.clip = _BGM_MiniBoss;
            _audioSource.time = 0;
            _audioSource.Play();
            _throughOnece = true;
        }
        if (!_isMiniBossStage && !_throughOnece && _audioSource.clip != _BGM_Field)
        {
            _audioSource.Stop();
            _audioSource.clip = _BGM_Field;
            _audioSource.time = 0;
            _audioSource.Play();
            _throughOnece = true;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeBGMByStage();
    }
}