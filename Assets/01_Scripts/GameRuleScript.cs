using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleScript : MonoBehaviour
{
    public GameObject _player;
    public GameObject _rule01Panel;
    public GameObject _rule02Panel;
    public GameObject _rule03Panel;
    public GameObject _nextButton;
    public GameObject _satrtButton;

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

    public void NextRules()
    {
        if (_rule01Panel.activeSelf)
        {
            _rule02Panel.SetActive(true);
            _rule01Panel.SetActive(false);
        }
        else if (_rule02Panel.activeSelf)
        {
            _rule03Panel.SetActive(true);
            _rule02Panel.SetActive(false);
            _nextButton.SetActive(false);
            _satrtButton.SetActive(true);
        }
    }
}