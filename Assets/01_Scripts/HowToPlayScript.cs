using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScript : MonoBehaviour
{
    public GameObject _howToPlayPanel01;
    public GameObject _howToPlayPanel02;
    public GameObject _backButton;
    public GameObject _nextButton;
    public GameObject _prevButton;
    public GameObject _startButton;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HowToPlay()
    {
        _howToPlayPanel01.SetActive(true);
        _backButton.SetActive(true);
        _nextButton.SetActive(true);

        _howToPlayPanel02.SetActive(false);
        _prevButton.SetActive(false);
        _startButton.SetActive(false);
    }

    public void Next()
    {
        _howToPlayPanel01.SetActive(false);
        _backButton.SetActive(false);
        _nextButton.SetActive(false);

        _howToPlayPanel02.SetActive(true);
        _prevButton.SetActive(true);
        _startButton.SetActive(true);
    }
    public void Back()
    {
        _howToPlayPanel01.SetActive(false);
        _backButton.SetActive(false);
        _nextButton.SetActive(false);

        _howToPlayPanel02.SetActive(false);
        _prevButton.SetActive(false);
        _startButton.SetActive(false);
    }
}
