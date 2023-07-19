using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleScript : MonoBehaviour
{
    public GameObject _player;
    public GameObject _startButton;
    public GameObject _nextButton;
    public GameObject _prevButton;
    public GameObject _titleButton;

    public GameObject _howTo01;
    public GameObject _howTo02;

    void Update()
    {
        if (gameObject.activeSelf)
        {
            _player.SetActive(false);
        }
        else
        {
            _player.SetActive(true);
        }
    }

    public void Next()
    {
        _howTo02.SetActive(true);
        _howTo01.SetActive(false);
        _startButton.SetActive(true);
        _prevButton.SetActive(true);
        _nextButton.SetActive(false);
        _titleButton.SetActive(false);
    }

    public void Prev()
    {
        _howTo02.SetActive(false);
        _howTo01.SetActive(true);
        _startButton.SetActive(false);
        _prevButton.SetActive(false);
        _nextButton.SetActive(true);
        _titleButton.SetActive(true);
    }

}