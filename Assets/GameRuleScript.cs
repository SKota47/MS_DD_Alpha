using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleScript : MonoBehaviour
{
    public GameObject _player;

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
}