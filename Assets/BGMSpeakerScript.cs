using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSpeakerScript : MonoBehaviour
{
    AudioSource _audioSource;   //BGMソース
    float _loopTime = 15.211f;   //ループする地点

    //シーンをまたいで再生する仕組み
    private static bool _isLoad = false;
    private void Awake()
    {
        //新しく生成したとき
        if (_isLoad)    //このオブジェクトが存在していたら
        {
            Destroy(gameObject);    //新しく作ったオブジェクトを消す 
            return;
        }
        _isLoad = true;
        DontDestroyOnLoad(gameObject);//シーン間で消させない指示
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.2f; //音量調整
    }

    void Update()
    {
        if (_audioSource.time >= 48.16f) //音楽の最後に到達したら_loopTimeから再生
        {
            _audioSource.time = _loopTime;
        }
    }
}