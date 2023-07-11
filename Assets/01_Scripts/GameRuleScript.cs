using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleScript : MonoBehaviour
{
    public GameObject _player;
    public GameObject _startButton;

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

        if (this.gameObject.activeSelf) _startButton.SetActive(true);
    }
}