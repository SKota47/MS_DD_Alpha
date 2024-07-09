using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/// <summary>
/// エンディング映像のスキップ
/// </summary>
public class EndingSceneSkip : MonoBehaviour
{
    public GameObject _video;
    private VideoPlayer _videoPlayer;
    // Start is called before the first frame update
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
