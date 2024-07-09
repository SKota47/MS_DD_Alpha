using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/// <summary>
/// 初期映像のスキップ
/// </summary>
public class OpeningSceneSkip : MonoBehaviour
{
    public GameObject _video;
    private VideoPlayer _videoPlayer;
    void Start()
    {
        _videoPlayer = _video.GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached += LoopPointReached;
        _videoPlayer.Play();
    }
    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
    public void LoopPointReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
}